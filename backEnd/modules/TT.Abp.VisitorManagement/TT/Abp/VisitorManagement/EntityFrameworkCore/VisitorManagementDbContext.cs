using Microsoft.EntityFrameworkCore;
using TT.Abp.VisitorManagement.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.VisitorManagement.EntityFrameworkCore
{
    [ConnectionStringName("VisitorManagement")]
    public class VisitorManagementDbContext : AbpDbContext<VisitorManagementDbContext>, IVisitorManagementDbContext
    {
        public DbSet<VisitorLog> VisitorLogs { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormItem> FormItems { get; set; }

        public VisitorManagementDbContext(DbContextOptions<VisitorManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureVisitorManagement();
        }
    }
}