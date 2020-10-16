using System;
using TT.Abp.Mall.Domain.Partners;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Partners.Dtos
{
    /// <summary>
    ///     <see cref="Partner" />
    /// </summary>
    public class PartnerDtoBase : EntityDto
    {
        private Guid UserId { get; set; }

        public string RealName { get; set; }

        public string Phone { get; set; }

        public string HeadImgUrl { get; set; }

        /// <summary>
        ///     可用余额
        /// </summary>
        public virtual decimal AvblBalance { get; set; }

        /// <summary>
        ///     不可用余额
        /// </summary>
        public virtual decimal UnavblBalance { get; set; }
    }
}