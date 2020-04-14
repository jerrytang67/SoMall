using System;
using System.Collections.Generic;
using TT.Abp.Mall.Application.Shops;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Orders;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Orders.Dtos
{
    /// <summary>
    /// <see cref="ProductOrder"/>
    /// </summary>
    public class ProductOrderDto : EntityDto<Guid>
    {
        public decimal? PricePaidIn { get; set; }

        public decimal PriceOriginal { get; set; }

        DateTime? DatetimeComplate { get; set; }

        public MallEnums.OrderState State { get; set; }

        public MallEnums.ProductOrderType Type { get; set; }

        public MallEnums.PayType PayType { get; set; }

        public string Comment { get; set; }

        public Guid? BuyerId { get; set; }

        public Guid? AddressId { get; set; }

        public string AddressRealName { get; set; }

        public string AddressNickName { get; set; }

        public string AddressPhone { get; set; }

        public string AddressLocationLable { get; set; }

        public string AddressLocationAddress { get; set; }

        public Guid? ManId { get; set; }

        public int PrintCount { get; set; } = 0; //打印次数统计

        public Guid? ShopId { get; protected set; }

        public MallShopDto Shop { get; set; }

        public List<ProductOrderItemDto> OrderItems { get; set; }
    }
}