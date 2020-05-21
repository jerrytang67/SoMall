using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using TT.Abp.AuditManagement.Application;
using TT.Abp.AuditManagement.Audits;
using TT.Abp.AuditManagement.Domain;
using TT.Abp.Mall.Definitions;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace TT.Abp.Modules.Tests.AuditManagement
{
    public class DefineTest : SoMallModulesTestBase
    {
        private IAuditDefinitionManager _auditDefinitionManager;
        private IAuditValueProviderManager _auditValueProvider;
        private IRepository<AuditFlow, Guid> _auditFlowRepository;
        private IAuditProvider _auditProvider;
        private IAuditManagementAppService _appService;

        public DefineTest()
        {
            _auditDefinitionManager = GetRequiredService<IAuditDefinitionManager>();
            _auditValueProvider = GetRequiredService<IAuditValueProviderManager>();
            _auditFlowRepository = GetRequiredService<IRepository<AuditFlow, Guid>>();
            _auditProvider = GetRequiredService<IAuditProvider>();
            _appService = GetRequiredService<IAuditManagementAppService>();
        }
        
        [Fact]
        public async Task DefinitionTest()
        {
            var audits = _auditDefinitionManager.GetAll();

            // define in mall Module
            audits.Count.ShouldBe(2);

            await Task.CompletedTask;
        }

        [Fact]
        public async Task ValueProviderTest()
        {
            var providers = _auditValueProvider.Providers;

            // define in mall Module
            providers.Count.ShouldBe(3);

            await Task.CompletedTask;
        }


        [Fact]
        public async Task AuditFlowTests()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                //Arrange
                var dbEntity = await _auditFlowRepository.InsertAsync(
                    new AuditFlow(
                        MallManagementAudit.ProductRefund,
                        true, 
                        "G",
                        null),
                    true);

                //Act
                var result = await _auditProvider.GetOrNullAsync(MallManagementAudit.ProductRefund);

                //Assert
                dbEntity.Enable.ShouldBe(true);
                dbEntity.ProviderName.ShouldBe("G");
                dbEntity.AuditName.ShouldBe(MallManagementAudit.ProductRefund);

                result.ShouldNotBeNull();
                result.ShouldBe(dbEntity.Id);
            });

            await Task.CompletedTask;
        }
    }
}