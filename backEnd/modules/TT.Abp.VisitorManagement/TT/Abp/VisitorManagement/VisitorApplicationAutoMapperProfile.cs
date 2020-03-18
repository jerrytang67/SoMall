using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TT.Abp.VisitorManagement.Application.Dtos;
using TT.Abp.VisitorManagement.Domain;

namespace TT.Abp.VisitorManagement
{
    public class VisitorApplicationAutoMapperProfile : Profile
    {
        public VisitorApplicationAutoMapperProfile()
        {
            CreateMap<Form, FormDto>()
                ;


            CreateMap<FormItem, FormItemDto>()
                .ForMember(x => x.Value, opt => opt.MapFrom(x => x.DefaultValue))
                .ForMember(x => x.Selections, opt =>
                    opt.MapFrom(x =>
                        JsonConvert.DeserializeObject<List<SelectionItem>>(x.SelectionJson)
                    )
                );

            CreateMap<FormItem, FormItemCreateOrEditDto>()
                .ForMember(x => x.Selections, opt =>
                    opt.MapFrom(x =>
                        JsonConvert.DeserializeObject<List<SelectionItem>>(x.SelectionJson)
                    )
                )
                .ReverseMap()
                .ForMember(x => x.FormId, opt => opt.Ignore())
                .ForMember(x => x.SelectionJson, opt =>
                    opt.MapFrom(x =>
                        JsonConvert.SerializeObject(x.Selections))
                )
                ;

            CreateMap<VisitorLog, VisitorLogDto>()
                .ForMember(x => x.Credential, opt => opt.Ignore())
                .ForMember(x => x.FormJson, opt => opt.MapFrom(x => JsonConvert.DeserializeObject<List<FormItemDto>>(x.FormJson)))
                .ForMember(x => x.Html, opt => opt.Ignore());
        }
    }
}