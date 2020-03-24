using System;
using System.Diagnostics.CodeAnalysis;
using TT.Abp.Shops.Domain;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Shops
{
    public interface IShopData : IAggregateRoot<Guid>, IMultiTenant
    {
        string Name { get; set; }

        string ShortName { get; set; }

        string LogoImage { get; set; }

        string Description { get; set; }
    }
}