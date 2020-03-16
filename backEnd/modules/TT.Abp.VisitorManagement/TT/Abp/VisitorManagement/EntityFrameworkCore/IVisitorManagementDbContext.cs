using Microsoft.EntityFrameworkCore;
using TT.Abp.VisitorManagement.Domain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.VisitorManagement.EntityFrameworkCore
{
    [ConnectionStringName("VisitorManagement")]
    public interface IVisitorManagementDbContext : IEfCoreDbContext
    {
        DbSet<VisitorLog> VisitorLogs { get; set; }
        DbSet<Credential> Credentials { get; set; }
        DbSet<Form> Forms { get; set; }
        DbSet<FormItem> FormItems { get; set; }
        DbSet<ShopForm> ShopForms { get; set; }

    }
}