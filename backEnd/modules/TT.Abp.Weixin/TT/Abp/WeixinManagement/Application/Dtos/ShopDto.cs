using System;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.WeixinManagement.Application.Dtos
{
    public class ShopDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string LogoImage { get; set; }
        
        public string CoverImage { get; set; }

        public string Description { get; set; }
    }
}