using System;
using System.Linq;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Definitions;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Products
{
    public class ProductSkuAppService
        : CrudAppService<ProductSku, ProductSkuDto, Guid, MallRequestDto, SkuCreateOrUpdateDto, SkuCreateOrUpdateDto>
    {
        public ProductSkuAppService(IRepository<ProductSku, Guid> repository) : base(repository)
        {
            base.GetListPolicyName = MallPermissions.Products.Default;
            base.CreatePolicyName = MallPermissions.Products.Create;
            base.UpdatePolicyName = MallPermissions.Products.Update;
            base.DeletePolicyName = MallPermissions.Products.Delete;
        }

        protected override IQueryable<ProductSku> CreateFilteredQuery(MallRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId)
                ;
        }
    }
}