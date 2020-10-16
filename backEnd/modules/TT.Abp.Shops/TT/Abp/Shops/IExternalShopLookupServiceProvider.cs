using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Shops.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Shops
{
    public interface IExternalShopLookupServiceProvider
    {
        Task<IShopData> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IShopData> FindByShortNameAsync(string shortName, CancellationToken cancellationToken = default);
    }
}