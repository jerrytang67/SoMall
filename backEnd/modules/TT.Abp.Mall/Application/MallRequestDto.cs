using System;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application
{
    public class MallRequestDto : PagedAndSortedResultRequestDto
    {
        public int? State { get; set; }
        public string Keywords { get; set; }

        public Guid? ShopId { get; set; }

        [CanBeNull] public string AppName { get; set; }
    }
}