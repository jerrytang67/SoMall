using System;
using TT.Abp.Mall.Domain.Orders;

namespace TT.Abp.Mall.Application.Orders.Dtos
{
    /// <summary>
    /// <see cref="ProductOrderItem"/>
    /// </summary>
    public class ProductOrderItemDto
    {
        public Guid SpuId { get; }
        public Guid SkuId { get; }
        public double Num { get; }
        public decimal SkuPrice { get; }
        public string SpuName { get; }
        public string SkuName { get; }
        public string SkuUnit { get; }
        public string SkuCoverImageUrl { get; }
        public decimal Discount { get; }
        public string Comment { get; }
    }
}