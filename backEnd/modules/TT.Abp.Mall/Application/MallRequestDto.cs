using System;
using JetBrains.Annotations;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application
{
    public class MallRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? ShopId { get; set; }

        [CanBeNull] public string AppName { get; set; }
    }
}