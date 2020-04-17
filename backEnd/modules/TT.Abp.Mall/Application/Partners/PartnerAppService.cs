using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Partners;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Partners
{
    public interface IPartnerAppService
    {
    }


    public class PartnerAppService : ApplicationService, IPartnerAppService
    {
        private readonly IRepository<Partner> _repository;

        public PartnerAppService(IRepository<Partner> repository)
        {
            _repository = repository;
        }

        public async Task<PartnerDto> GetAsync(Guid userId)
        {
            var find = await _repository.FirstOrDefaultAsync(x => x.UserId == userId);

            return ObjectMapper.Map<Partner, PartnerDto>(find);
        }
    }

    public class PartnerDtoBase : EntityDto
    {
        Guid UserId { get; set; }

        public string RealName { get; set; }

        public string Phone { get; set; }

        public string Nickname { get; set; }

        public string HeadImageUrl { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public virtual decimal AvblBalance { get; set; }

        /// <summary>
        /// 不可用余额
        /// </summary>
        public virtual decimal UnavblBalance { get; set; }
    }

    public class PartnerDto : PartnerDtoBase
    {
        public DateTime UpdateDate { get; set; }

        public MallEnums.PartnerState State { get; set; }

        /// <summary>
        /// 已提现总数
        /// </summary>
        public virtual decimal TotalWithdrawals { get; set; }

        public DateTime? LastLoginDate { get; set; }

        //locaton info
        public virtual double? Lat { get; set; }

        public virtual double? Lng { get; set; }

        public virtual string LocationLabel { get; set; }

        public virtual string LocationAddress { get; set; }

        public PartnerDetail Detail { get; set; }
    }
}