using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.AuditManagement.Domain;
using TT.Abp.Shops;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace TT.Abp.AuditManagement.Audits
{
    public class ShopAuditValueProvider : AuditValueProvider
    {
        private readonly ICurrentShop _currentShop;
        private readonly IShopIdProvider _shopIdProvider;
        public const string ProviderName = "S";

        public override string Name => ProviderName;

        public ShopAuditValueProvider(
            IRepository<AuditFlow, Guid> auditFlowRepository,
            ICurrentShop currentShop
        ) : base(auditFlowRepository)
        {
            _currentShop = currentShop;
        }

        [UnitOfWork]
        public override async Task<Guid?> GetOrNullAsync(AuditDefinition audit)
        {
            if (_currentShop.Id == null)
            {
                return null;
            }

            var dbEntity = await AuditFlowRepository
                .FirstOrDefaultAsync(
                    x => x.ProviderName == ProviderName
                         && x.AuditName == audit.Name
                         && x.Enable
                         && x.ProviderKey == _currentShop.Id.ToString()
                );

            return dbEntity?.Id;
        }
    }
}