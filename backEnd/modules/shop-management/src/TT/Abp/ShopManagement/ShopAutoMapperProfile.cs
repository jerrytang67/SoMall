using AutoMapper;
using TT.Abp.ShopManagement.Application;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.ShopManagement.Domain;

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