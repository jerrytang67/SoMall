using System;
using AutoMapper;
using TT.Abp.Mall.Application.Addresses;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Coupons;
using TT.Abp.Mall.Application.Coupons.Dtos;
using TT.Abp.Mall.Application.Orders;
using TT.Abp.Mall.Application.Orders.Dtos;
using TT.Abp.Mall.Application.Partners;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Application.Users;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Mall.Domain.Users;

namespace TT.Abp.Mall
{
    public class MallApplicationAutoMapperProfile : Profile
    {
        public MallApplicationAutoMapperProfile()
        {
            CreateMap<MallUser, MallUserDto>();

            #region Shops

            CreateMap<MallShop, MallShopDto>();

            #endregion


            #region Products

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductSpu, ProductSpuDto>();
            CreateMap<ProductSku, ProductSkuDto>()
                .ForMember(x => x.ShopId, opt => opt.MapFrom(x => x.Spu.ShopId))
                .ForMember(x => x.SpuName, opt => opt.MapFrom(x => x.Spu.Name))
                ;

            CreateMap<CategoryCreateOrUpdateDto, ProductCategory>();

            CreateMap<SpuCreateOrUpdateDto, ProductSpu>()
                .ForMember(x => x.Skus, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SkuCreateOrUpdateDto, ProductSku>()
                .ReverseMap();

            #endregion


            #region Address

            CreateMap<Address, AddressDto>()
                .ForMember(x => x.MallUser, opt => opt.Ignore());

            CreateMap<AddressCreateOrUpdateDto, Address>()
                .ReverseMap();

            #endregion

            #region Orders

            CreateMap<ProductOrder, ProductOrderDto>()
                .ForMember(x => x.OrderItems, opt => opt.MapFrom(x => x.OrderItems))
                ;

            CreateMap<ProductOrderItem, ProductOrderItemDto>()
                ;

            #endregion

            #region Partners

            CreateMap<Partner, PartnerDto>();

            #endregion


            #region Coupons

            CreateMap<Coupon, CouponDto>();
            
            CreateMap<CouponCreateOrUpdateDto, Coupon>();

            #endregion
        }
    }
}