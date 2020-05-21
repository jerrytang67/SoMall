using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TT.Abp.AuditManagement.Application.Dtos;
using TT.Abp.AuditManagement.Audits;
using TT.Abp.AuditManagement.Domain;
using TT.Extensions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AuditManagement.Application
{
    public interface IAuditFlowAppService : ICrudAppService<AuditFlowDto,
        Guid,
        PagedResultRequestDto,
        AuditFlowCreateOrEditDto,
        AuditFlowCreateOrEditDto>
    {
        Task<GetForEditOutput<AuditFlowCreateOrEditDto>> GetForEdit(Guid id);
    }

    public class AuditFlowAppService :
        CrudAppService<
            AuditFlow,
            AuditFlowDto,
            Guid,
            PagedResultRequestDto,
            AuditFlowCreateOrEditDto,
            AuditFlowCreateOrEditDto>, IAuditFlowAppService
    {
        private readonly IAuditDefinitionManager _auditDefinitionManager;

        public AuditFlowAppService(
            IRepository<AuditFlow, Guid> repository
            , IAuditDefinitionManager auditDefinitionManager
        ) : base(repository)
        {
            _auditDefinitionManager = auditDefinitionManager;
        }

        // [Authorize]
        public async Task<GetForEditOutput<AuditFlowCreateOrEditDto>> GetForEdit(Guid id)
        {
            var find = await Repository
                .Include(x => x.AuditNodes)
                .FirstOrDefaultAsync(z => z.Id == id);

            var schema = JToken.FromObject(new { });

            var audits = _auditDefinitionManager.GetAll();
            schema["audits"] = audits.GetSelection("string", "name", @"{0}", new[] {"Name"}, "Name");

            return new GetForEditOutput<AuditFlowCreateOrEditDto>(
                ObjectMapper.Map<AuditFlow, AuditFlowCreateOrEditDto>(find), schema);
        }
    }

    public class GetForEditOutput<T>
    {
        public GetForEditOutput(T company, JToken schema)
        {
            data = company;
            Schema = schema;
        }

        public T data { get; set; }

        public JToken Schema { get; set; }
    }
}