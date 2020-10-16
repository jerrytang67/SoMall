using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Shops
{
    public interface IShop : IAggregateRoot<Guid>, IMultiTenant
    {
        string Name { get; }

        string ShortName { get; }

        string LogoImage { get; }

        string CoverImage { get; set; }

        string Description { get; }
    }
}