using AutoMapper;
using TT.Abp.Shops.Application.Dtos;
using TT.Abp.Shops.Domain;

namespace TT.Abp.Shops
{
    public class ShopApplicationAutoMapperProfile : Profile
    {
        public ShopApplicationAutoMapperProfile()
        {
            CreateMap<Shop, ShopDto>();
            
            
        }
    }
}