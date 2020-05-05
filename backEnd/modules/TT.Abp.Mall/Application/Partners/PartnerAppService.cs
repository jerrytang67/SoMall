using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Partners;
using TT.SoMall.Users;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Partners
{
    public interface IPartnerAppService
    {
        Task<PartnerDto> GetAsync(Guid userId);
        Task<PagedResultDto<PartnerDto>> GetListAsync(MallRequestDto input);

        Task PublicEdit(PartnerCreateOrUpdateDto input);
    }


    public class PartnerAppService : ApplicationService, IPartnerAppService
    {
        private readonly IRepository<Partner> _repository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public PartnerAppService(
            IRepository<Partner> repository
            , IRepository<AppUser, Guid> userRepository
        )
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<PartnerDto> GetAsync(Guid userId)
        {
            var find = await _repository.FirstOrDefaultAsync(x => x.UserId == userId);

            return ObjectMapper.Map<Partner, PartnerDto>(find);
        }

        public async Task<PagedResultDto<PartnerDto>> GetListAsync(MallRequestDto input)
        {
            var query = _repository.AsQueryable();

            var totalCount = await query.CountAsync();

            query = query.OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "creationTime desc" : input.Sorting);
            query = query.PageBy(input);

            var entities = await query.ToListAsync();

            return new PagedResultDto<PartnerDto>(
                totalCount,
                ObjectMapper.Map<List<Partner>, List<PartnerDto>>(entities)
            );
        }


        [Authorize]
        [HttpPost]
        public async Task PublicEdit(PartnerCreateOrUpdateDto input)
        {
            var find = await _repository.FirstOrDefaultAsync(x => x.UserId == CurrentUser.Id);
            if (find == null)
            {
                find = new Partner(CurrentUser.Id.Value);
                ObjectMapper.Map(input, find);
                await _repository.InsertAsync(find, true);
            }
            else
            {
                ObjectMapper.Map(input, find);
                await _repository.UpdateAsync(find, true);
            }

            await Task.CompletedTask;
        }
    }

    /// <summary>
    /// <see cref="Partner"/>
    /// </summary>
    public class PartnerCreateOrUpdateDto
    {
        [Required] [DisplayName("姓名")] public string RealName { get; set; }
        [Required] [DisplayName("电话")] public string Phone { get; set; }
        [DisplayName("备用电话")] public string PhoneBackup { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        [Required] [DisplayName("地址")] public string LocationLabel { get; set; }
        public string LocationAddress { get; set; }
        public MallEnums.LocationType LocationType { get; set; }
        [Required] public string Introducting { get; set; }
    }
}