using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.AuditManagement.EntityFrameworkCore
{
    [ConnectionStringName("AuditManagement")]
    public class AuditManagementDbContext :
        AbpDbContext<AuditManagementDbContext>,
        IAuditManagementDbContext
    {
        public AuditManagementDbContext(
            DbContextOptions<AuditManagementDbContext> options
        )
            : base(options)
        {
        }

        public virtual DbSet<AuditFlow> AuditFlows { get; set; }

        public virtual DbSet<AuditNode> AuditNodes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAuditManagement();
        }
    }
}