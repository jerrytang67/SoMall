using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using Volo.Abp.Users;

namespace TT.Abp.Core.Application
{
    public class AuditLogAppService : ApplicationService
    {
        private readonly IAuditLogRepository _auditlogRepository;

        public AuditLogAppService(
            IAuditLogRepository auditlogRepository
        )
        {
            _auditlogRepository = auditlogRepository;
        }

        [HttpGet]
        public async Task<PagedResultDto<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input)
        {
            var query = _auditlogRepository.AsQueryable();

            query = query
                .WhereIf(input.MinExecutionDuration.HasValue && input.MinExecutionDuration > 0, item => item.ExecutionDuration >= input.MinExecutionDuration.Value)
                .WhereIf(input.MaxExecutionDuration.HasValue && input.MaxExecutionDuration < int.MaxValue, item => item.ExecutionDuration <= input.MaxExecutionDuration.Value)
                .WhereIf(input.HasException == true, item => item.Exceptions != null && item.Exceptions != "")
                .WhereIf(input.HasException == false, item => item.Exceptions == null || item.Exceptions == "");

            var resultCount = await query.CountAsync();
            var results = await query
                .OrderBy(input.Sorting??"executionTime desc")
                .PageBy(input)
                .ToListAsync();

            var auditLogListDtos = ObjectMapper.Map<List<AuditLog>, List<AuditLogListDto>>(results);

            return new PagedResultDto<AuditLogListDto>(resultCount, auditLogListDtos);
        }
    }

    public class GetAuditLogsInput : PagedAndSortedResultRequestDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; } = DateTime.Now;

        public string UserName { get; set; }

        public string ServiceName { get; set; }

        public string MethodName { get; set; }

        public string BrowserInfo { get; set; }

        public bool? HasException { get; set; }

        public int? MinExecutionDuration { get; set; }

        public int? MaxExecutionDuration { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "Id DESC";
            }

            if (Sorting.IndexOf("UserName", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Sorting = "User." + Sorting;
            }
            else
            {
                Sorting = "AuditLog." + Sorting;
            }
        }
    }


    public class AuditLogAndUser
    {
        public AuditLog AuditLog { get; set; }

        public IUser User { get; set; }
    }

    public class AuditLogListDto
    {
        public string ApplicationName { get; set; }

        public Guid? UserId { get; set; }

        public string UserName { get; set; }
        
        public Guid? TenantId { get; set; }

        public string TenantName { get; set; }

        public Guid? ImpersonatorUserId { get; set; }

        public Guid? ImpersonatorTenantId { get; set; }

        public DateTime ExecutionTime { get; set; }

        public int ExecutionDuration { get; set; }

        public string ClientIpAddress { get; set; }

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string CorrelationId { get; set; }

        public string BrowserInfo { get; set; }

        public string HttpMethod { get; set; }

        public string Url { get; set; }

        public string Exceptions { get; set; }

        public string Comments { get; set; }

        public int? HttpStatusCode { get; set; }

        public List<EntityChange> EntityChanges { get; set; }

        public List<AuditLogAction> Actions { get; set; }
    }
}