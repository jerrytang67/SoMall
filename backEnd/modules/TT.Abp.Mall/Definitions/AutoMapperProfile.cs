using AutoMapper;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Coupons.Dtos;
using TT.Abp.Mall.Application.Orders.Dtos;
using TT.Abp.Mall.Application.Partners;
using TT.Abp.Mall.Application.Partners.Dtos;
using TT.Abp.Mall.Application.Pays;
using TT.Abp.Mall.Application.Products.Dtos;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Application.Swipers;
using TT.Abp.Mall.Application.Swipers.Dtos;
using TT.Abp.Mall.Application.Users;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Addresses;
using TT.Abp.Mall.Domain.Orders;
using TT.Abp.Mall.Domain.Partners;
using TT.Abp.Mall.Domain.Pays;
using TT.Abp.Mall.Domain.Products;
using TT.Abp.Mall.Domain.Shops;
using TT.Abp.Mall.Domain.Swipers;
using TT.Abp.Mall.Domain.Users;

namespace TT.Abp.Mall.Definitions
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
            CreateMap<ProductCategory, CategoryCreateOrUpdateDto>();

            CreateMap<AppProductCategory, AppProductCategoryDto>()
                .ForMember(x => x.ProductCategoryName, opt => opt.MapFrom(x => x.ProductCategory.Name))
                .ReverseMap()
                ;

            CreateMap<AppProductSpu, AppProductSpuDto>()
                .ReverseMap()
                ;

            CreateMap<ProductSpu, ProductSpuDto>();
            CreateMap<ProductSpu, ProductSpuDtoBase>();
            CreateMap<ProductSku, ProductSkuDto>()
                .ForMember(x => x.ShopId, opt => opt.MapFrom(x => x.Spu.ShopId))
                .ForMember(x => x.SpuName, opt => opt.MapFrom(x => x.Spu.Name))
                ;

            CreateMap<CategoryCreateOrUpdateDto, ProductCategory>()
                .ForMember(x => x.AppProductCategories, opt => opt.Ignore());

            CreateMap<SpuCreateOrUpdateDto, ProductSpu>()
                .ForMember(x => x.Skus, opt => opt.Ignore())
                .ForMember(x => x.AppProductSpus, opt => opt.Ignore())
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
            CreateMap<PartnerCreateOrUpdateDto, Partner>()
                .AfterMap((src, dest) => dest.Detail.Introducting = src.Introducting)
                .ReverseMap()
                .AfterMap((src, dest) => dest.Introducting = src.Detail.Introducting)
                ;

            #endregion

            #region Coupons

            CreateMap<Coupon, CouponDto>();

            CreateMap<CouponCreateOrUpdateDto, Coupon>();

            #endregion


            #region Pays

            CreateMap<PayOrder, PayOrderDto>();

            CreateMap<PayOrder, PayOrderDtoBase>();

            CreateMap<TenPayNotify, TenPayNotifyDto>();

            #endregion

            CreateMap<Swiper, SwiperDto>();
            CreateMap<Swiper, SwiperCreateOrUpdateDto>()
                .ReverseMap();

            CreateMap<RefundLog, RefundLogDto>();
        }
    }
}