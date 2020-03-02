using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.SoMall.Products
{
    public class ProductCategoryAppService
        : CrudAppService<ProductCategory, ProductCategoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>
    {
        public ProductCategoryAppService(IRepository<ProductCategory, Guid> repository) : base(repository)
        {
        }
    }

    public class ProductSpuAppService
          : CrudAppService<ProductSpu, ProductSpuDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSpuDto, CreateUpdateSpuDto>
    {
        public ProductSpuAppService(IRepository<ProductSpu, Guid> repository) : base(repository)
        {
        }
    }

    public class ProductSkuAppService
          : CrudAppService<ProductSku, ProductSkuDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSkuDto, CreateUpdateSkuDto>
    {
        public ProductSkuAppService(IRepository<ProductSku, Guid> repository) : base(repository)
        {
        }
    }



}
