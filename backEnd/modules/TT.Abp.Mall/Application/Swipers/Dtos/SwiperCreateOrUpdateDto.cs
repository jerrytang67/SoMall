using System;
using TT.Abp.Mall.Domain.Swipers;

namespace TT.Abp.Mall.Application.Swipers
{
    /// <summary>
    /// <see cref="Swiper"/>
    /// </summary>
    public class SwiperCreateOrUpdateDto
    {
        public string GroupName { get; protected set; }

        public string AppName { get; protected set; }

        public string CoverImageUrl { get; protected set; }

        public string Name { get; set; }

        public string RedirectUrl { get; set; }

        public int State { get; set; }

        public int Sort { get; set; }

        public Guid? ShopId { get; set; }
    }
}