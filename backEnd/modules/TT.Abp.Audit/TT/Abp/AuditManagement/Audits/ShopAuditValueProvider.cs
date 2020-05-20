using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.AuditManagement.Audits
{
    public class ShopAuditValueProvider : AuditValueProvider
    {
        private readonly IShopIdProvider _shopIdProvider;
        public const string ProviderName = "S";

        public override string Name => ProviderName;

        public ShopAuditValueProvider(
            IRepository<AuditFlow, Guid> auditFlowRepository,
            IShopIdProvider shopIdProvider
        ) : base(auditFlowRepository)
        {
            _shopIdProvider = shopIdProvider;
        }

        [UnitOfWork]
        public override async Task<Guid?> GetOrNullAsync(AuditDefinition audit)
        {
            var shopId = await _shopIdProvider.GetCurrentShopId();

            if (shopId == null)
            {
                return null;
            }

            var dbEntity = await AuditFlowRepository
                .FirstOrDefaultAsync(
                    x => x.ProviderName == ProviderName
                         && x.AuditName == audit.Name
                         && x.Enable
                         && x.ProviderKey == shopId.ToString()
                );

            return dbEntity?.Id;
        }
    }
}