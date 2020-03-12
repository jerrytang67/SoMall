using System;

namespace TT.Abp.ShopManagement.Application.Dtos
{
    public class UpdateShopDto
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string CoverImage { get; set; }

        public string Description { get; set; }
    }
}