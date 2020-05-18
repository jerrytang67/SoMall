using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using Volo.Abp.Domain.Repositories;

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

        public override async Task<Guid?> GetOrNullAsync(AuditDefinition audit)
        {
            var shopId = _shopIdProvider.GetCurrentShopId();

            if (shopId == null)
            {
                return null;
            }

            var dbEntity = await AuditFlowRepository
                .FirstOrDefaultAsync(
                    x => x.ProviderKey == ProviderName
                         && x.AuditName == audit.Name
                         && x.Enable
                         && x.ProviderKey == shopId.ToString()
                );

            return dbEntity?.Id;
        }
    }
}