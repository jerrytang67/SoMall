using System;
using System.Collections.Generic;

namespace TT.Abp.Shops.Application.Dtos
{
    public class ShopSyncRequestDto
    {
        public List<Guid> ShopIds { get; set; }
    }
}