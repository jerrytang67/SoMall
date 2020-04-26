using AutoMapper;
using TT.Abp.Core.Application;
using Volo.Abp.AuditLogging;

namespace TT.Abp.Core
{
    public class TtCoreAutoMapperProfile : Profile
    {
        public TtCoreAutoMapperProfile()
        {
            CreateMap<AuditLog, AuditLogListDto>();
        }
    }
}