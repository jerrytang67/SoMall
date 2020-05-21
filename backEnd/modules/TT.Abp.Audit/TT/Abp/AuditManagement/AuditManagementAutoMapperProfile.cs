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
                .ReverseMap();

            CreateMap<AuditNode, AuditNodeDto>();

            CreateMap<AuditNodeCreateOrEditDto, AuditNode>()
                .ReverseMap();
        }
    }
}