using System;
using JetBrains.Annotations;
using TT.Abp.Mall.Domain;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application
{
    public class MallRequestDto : PagedAndSortedResultRequestDto
    {
        public int? State { get; set; }
        public string Keywords { get; set; }

        public Guid? ShopId { get; set; }

        public Guid? SpuId { get; set; }

        public Guid? SkuId { get; set; }
        
        [CanBeNull] public string AppName { get; set; }

        public MallEnums.LocationType LocationType { get; set; } = MallEnums.LocationType.bd09;
    }
}