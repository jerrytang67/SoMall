using System;
using TT.Abp.Mall.Domain.Swipers;

namespace TT.Abp.Mall.Application.Swipers.Dtos
{
    /// <summary>
    /// <see cref="Swiper"/>
    /// </summary>
    public class SwiperCreateOrUpdateDto
    {
        public string GroupName { get;  set; }

        public string AppName { get;  set; }

        public string CoverImageUrl { get;  set; }

        public string Name { get; set; }

        public string RedirectUrl { get; set; }

        public int State { get; set; }

        public int Sort { get; set; }

        public Guid? ShopId { get; set; }
    }
}