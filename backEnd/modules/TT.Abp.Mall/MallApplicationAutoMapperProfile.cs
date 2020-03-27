using AutoMapper;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Domain.Products;

namespace TT.Abp.Mall
{
    public class MallApplicationAutoMapperProfile : Profile
    {
        public MallApplicationAutoMapperProfile()
        {
            #region Products

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductSpu, ProductSpuDto>();
            CreateMap<ProductSku, ProductSkuDto>();


            CreateMap<CreateUpdateCategoryDto, ProductCategory>();
            CreateMap<CreateUpdateSpuDto, ProductSpu>();
            CreateMap<CreateUpdateSkuDto, ProductSku>();

            #endregion
        }
    }
}