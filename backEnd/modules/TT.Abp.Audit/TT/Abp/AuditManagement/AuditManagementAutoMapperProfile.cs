using System.Linq;
using AutoMapper;
using TT.Abp.AuditManagement.Application.Dtos;
using TT.Abp.AuditManagement.Domain;

namespace TT.Abp.AuditManagement
{
    public class AuditManagementAutoMapperProfile : Profile
    {
        public AuditManagementAutoMapperProfile()
        {
            CreateMap<AuditFlow, AuditFlowDto>();

            CreateMap<AuditFlowCreateOrEditDto, AuditFlow>()
                .ForMember(x => x.NodesMaxIndex,
                    opt => opt.MapFrom(x => x.AuditNodes.Max(xx => xx.Index)))
                .ReverseMap();

            CreateMap<AuditNode, AuditNodeDto>();

            CreateMap<AuditNodeCreateOrEditDto, AuditNode>()
                .ReverseMap();
        }
    }
}