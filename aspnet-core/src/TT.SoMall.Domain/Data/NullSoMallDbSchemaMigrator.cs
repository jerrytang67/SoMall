using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TT.SoMall.Data
{
    /* This is used if database provider does't define
     * ISoMallDbSchemaMigrator implementation.
     */
    public class NullSoMallDbSchemaMigrator : ISoMallDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}