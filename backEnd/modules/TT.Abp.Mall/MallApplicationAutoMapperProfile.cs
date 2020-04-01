using System;
using AutoMapper;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;

namespace TT.Abp.Mall
{
    public class MallApplicationAutoMapperProfile : Profile
    {
        public MallApplicationAutoMapperProfile()
        {
            #region Shops

            CreateMap<MallShop, MallShopDto>();

            #endregion


            #region Products

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductSpu, ProductSpuDto>();
            CreateMap<ProductSku, ProductSkuDto>();


            CreateMap<CategoryCreateOrUpdateDto, ProductCategory>();

            CreateMap<SpuCreateOrUpdateDto, ProductSpu>()
                .ForMember(x => x.Skus, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SkuCreateOrUpdateDto, ProductSku>()
                .ReverseMap();

            #endregion
        }
    }
}