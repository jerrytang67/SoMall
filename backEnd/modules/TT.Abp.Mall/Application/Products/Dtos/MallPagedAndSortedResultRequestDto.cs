using System;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Products.Dtos
{
    public class MallPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? ShopId { get; set; }
    }
}