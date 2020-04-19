using AutoMapper;
using TT.SoMall.Dtos;
using TT.SoMall.Users;

namespace TT.SoMall
{
    public class SoMallApplicationAutoMapperProfile : Profile
    {
        public SoMallApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AppUser, UserProfileInput>();
        }
    }
}