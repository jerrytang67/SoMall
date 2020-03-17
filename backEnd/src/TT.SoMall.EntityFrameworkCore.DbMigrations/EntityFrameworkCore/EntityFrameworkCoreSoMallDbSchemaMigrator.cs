using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TT.SoMall.Data;
using Volo.Abp.DependencyInjection;

namespace TT.SoMall.EntityFrameworkCore
{
    public class EntityFrameworkCoreSoMallDbSchemaMigrator
        : ISoMallDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreSoMallDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the SoMallMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<SoMallMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}