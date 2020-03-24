using AutoMapper;
using TT.Abp.ShopManagement.Application;
using TT.Abp.ShopManagement.Application.Dtos;

namespace TT.Abp.ShopManagement
{
    public class ShopApplicationAutoMapperProfile : Profile
    {
        public ShopApplicationAutoMapperProfile()
        {
            CreateMap<VisitorShop, VisitorShopDto>();
        }
    }
}