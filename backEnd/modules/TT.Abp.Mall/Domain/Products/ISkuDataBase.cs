using System;
using System.Diagnostics.CodeAnalysis;

namespace TT.Abp.Mall.Domain.Products
{
    public interface ISkuDataBase
    {
        Guid SpuId { get; }
        [NotNull] string Name { get; }
        string Code { get; }
        decimal Price { get; }
    }
}