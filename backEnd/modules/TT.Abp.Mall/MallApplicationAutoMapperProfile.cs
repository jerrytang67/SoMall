using AutoMapper;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.MallManagement.Application.Products.Dtos;

namespace TT.Abp.MallManagement
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