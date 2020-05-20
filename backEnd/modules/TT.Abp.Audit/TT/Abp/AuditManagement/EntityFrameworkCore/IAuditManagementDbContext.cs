using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AuditManagement.EntityFrameworkCore
{
    [ConnectionStringName("AuditManagement")]
    public interface IAuditManagementDbContext : IEfCoreDbContext
    {
        DbSet<AuditFlow> AuditFlows { get; set; }
        DbSet<AuditNode> AuditNodes { get; set; }
    }
}