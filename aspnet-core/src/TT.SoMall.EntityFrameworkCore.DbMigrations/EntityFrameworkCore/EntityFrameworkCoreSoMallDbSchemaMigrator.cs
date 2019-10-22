using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.SoMall.Data;
using Volo.Abp.DependencyInjection;

namespace TT.SoMall.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreSoMallDbSchemaMigrator 
        : ISoMallDbSchemaMigrator, ITransientDependency
    {
        private readonly SoMallMigrationsDbContext _dbContext;

        public EntityFrameworkCoreSoMallDbSchemaMigrator(SoMallMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}