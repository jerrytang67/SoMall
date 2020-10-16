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
        public const string ProviderName = "S";
        private readonly ICurrentShop _currentShop;
        private readonly IShopIdProvider _shopIdProvider;

        public ShopAuditValueProvider(
            IRepository<AuditFlow, Guid> auditFlowRepository,
            ICurrentShop currentShop
        ) : base(auditFlowRepository)
        {
            _currentShop = currentShop;
        }

        public override string Name => ProviderName;

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