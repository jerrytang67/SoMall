using System;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application
{
    public class MallRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? ShopId { get; set; }
    }
}