using AutoMapper;
using TT.Abp.AppManagement.Application;
using TT.Abp.AppManagement.Domain;

namespace TT.Abp.AppManagement
{
    public class AppManagementModuleAutoMapperProfile : Profile
    {
        public AppManagementModuleAutoMapperProfile()
        {
            CreateMap<App, AppDto>();
            CreateMap<AppCreateOrUpdateDto, App>();
        }
    }
}