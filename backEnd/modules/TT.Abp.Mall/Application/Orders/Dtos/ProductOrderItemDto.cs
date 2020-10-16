using System;
using TT.Abp.Mall.Domain.Orders;

namespace TT.Abp.Mall.Application.Orders.Dtos
{
    /// <summary>
    ///     <see cref="ProductOrderItem" />
    /// </summary>
    public class ProductOrderItemDto
    {
        public Guid SpuId { get; set; }
        public Guid SkuId { get; set; }
        public double Num { get; set; }
        public decimal SkuPrice { get; set; }
        public string SpuName { get; set; }
        public string SkuName { get; set; }
        public string SkuUnit { get; set; }
        public string SkuCoverImageUrl { get; set; }
        public decimal Discount { get; set; }
        public string Comment { get; set; }
    }
}