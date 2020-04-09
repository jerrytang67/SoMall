using System;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Addresses
{
    public class AddressDto : EntityDto<Guid>
    {
        public string RealName { get; set; }

        public string Phone { get; set; }

        public string LocationLable { get; set; }

        public string LocationAddress { get; set; }

        public string NickName { get; set; }

        //是否为默认地址
        public bool IsDefault { get; set; } = false;

        //最后一次使用这个地址时间
        public DateTime? DatetimeLast { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public LocationType LocationType { get; set; }
    }
}