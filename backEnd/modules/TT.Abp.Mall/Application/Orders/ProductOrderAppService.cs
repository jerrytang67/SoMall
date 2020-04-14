using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Application.Orders.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Orders;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Orders
{
    public interface IProductOrderAppService : ICrudAppService<ProductOrderDto, Guid, PagedAndSortedResultRequestDto, ProductOrderCreateOrUpdateDto, ProductOrderCreateOrUpdateDto>
    {
    }

    public class ProductOrderAppService :
        CrudAppService<ProductOrder, ProductOrderDto, Guid, PagedAndSortedResultRequestDto, ProductOrderCreateOrUpdateDto, ProductOrderCreateOrUpdateDto>,
        IProductOrderAppService
    {
        private readonly IMallShopLookupService _mallShopLookupService;

        public ProductOrderAppService(IRepository<ProductOrder, Guid> repository, IMallShopLookupService mallShopLookupService) : base(repository)
        {
            _mallShopLookupService = mallShopLookupService;
            base.GetListPolicyName = MallPermissions.ProductOrders.Default;
            base.GetPolicyName = MallPermissions.ProductOrders.Default;
            base.UpdatePolicyName = MallPermissions.ProductOrders.Update;
            base.DeletePolicyName = MallPermissions.ProductOrders.Delete;
        }

        public override async Task<ProductOrderDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var entity = await Repository.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);

            return MapToGetOutputDto(entity);
        }

        public override async Task<PagedResultDto<ProductOrderDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var result = await base.GetListAsync(input);

            var shopDictionary = new Dictionary<Guid, MallShopDto>();

            foreach (var dto in result.Items)
            {
                if (dto.ShopId.HasValue)
                {
                    if (!shopDictionary.ContainsKey(dto.ShopId.Value))
                    {
                        var shop = await _mallShopLookupService.FindByIdAsync(dto.ShopId.Value);
                        if (shop != null)
                        {
                            shopDictionary[shop.Id] = ObjectMapper.Map<MallShop, MallShopDto>(shop);
                        }
                    }

                    if (shopDictionary.ContainsKey(dto.ShopId.Value))
                    {
                        dto.Shop = shopDictionary[(Guid) dto.ShopId];
                    }
                }
            }

            return result;
        }

        public override Task<ProductOrderDto> CreateAsync(ProductOrderCreateOrUpdateDto input)
        {
            throw new Exception("not use");
        }

        protected override IQueryable<ProductOrder> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            return base.CreateFilteredQuery(input).Include(x => x.OrderItems);
        }
    }
}