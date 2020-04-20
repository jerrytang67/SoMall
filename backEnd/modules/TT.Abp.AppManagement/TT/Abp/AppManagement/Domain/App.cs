using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace TT.Abp.AppManagement.Domain
{
    public class App : FullAuditedAggregateRoot<Guid>
    {
        [NotNull] public string Name { get; set; }

        [NotNull] public string ClientName { get; set; }
    }
}