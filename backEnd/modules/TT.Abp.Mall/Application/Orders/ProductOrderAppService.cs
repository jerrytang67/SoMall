using System;
using System.Threading.Tasks;
using TT.Abp.Mall.Domain.Orders;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using TT.Abp.Mall.Domain.Products;
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
        public ProductOrderAppService(IRepository<ProductOrder, Guid> repository) : base(repository)
        {
        }

        public override async Task<ProductOrderDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var entity = await GetEntityByIdAsync(id);
            return MapToGetOutputDto(entity);


            return base.GetAsync(id);
        }

        public override Task<ProductOrderDto> CreateAsync(ProductOrderCreateOrUpdateDto input)
        {
            throw new Exception("not use");
        }
    }


    public class ProductOrderDto : EntityDto<Guid>
    {
    }

    public class ProductOrderCreateOrUpdateDto
    {
    }
}