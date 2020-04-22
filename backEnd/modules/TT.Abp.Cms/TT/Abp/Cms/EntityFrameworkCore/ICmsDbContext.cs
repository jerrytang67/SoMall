using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TT.Abp.Cms.EntityFrameworkCore
{
    [ConnectionStringName("Cms")]
    public interface ICmsDbContext : IEfCoreDbContext
    {
    }
}