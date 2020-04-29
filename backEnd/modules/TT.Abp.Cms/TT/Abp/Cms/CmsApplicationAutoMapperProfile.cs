using AutoMapper;
using TT.Abp.Cms.Application;
using TT.Abp.Cms.Domain;

namespace TT.Abp.Cms
{
    public class CmsApplicationAutoMapperProfile : Profile
    {
        public CmsApplicationAutoMapperProfile()
        {
            // CreateMap<MallUser, MallUserDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateOrUpdate, Category>()
                .ReverseMap();
        }
    }
}