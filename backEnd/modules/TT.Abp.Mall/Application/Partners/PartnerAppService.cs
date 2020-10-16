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
using TT.Abp.Mall.Application.Partners.Dtos;
using TT.Abp.Mall.Domain;
using TT.Abp.Mall.Domain.Partners;
using TT.Extensions;
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

        Task<PartnerCreateOrUpdateDto> GetCurrent();
    }


    public class PartnerAppService : ApplicationService, IPartnerAppService
    {
        private readonly IRepository<Partner> _repository;

        public PartnerAppService(
            IRepository<Partner> repository
        )
        {
            _repository = repository;
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

            var resultDtos = ObjectMapper.Map<List<Partner>, List<PartnerDto>>(entities);

            foreach (var dto in resultDtos)
            {
                (dto.Lat, dto.Lng) = ConvertGeo(dto.Lat, dto.Lng, dto.LocationType, input.LocationType);
            }

            return new PagedResultDto<PartnerDto>(
                totalCount,
                resultDtos
            );
        }


        [Authorize]
        public async Task<PartnerCreateOrUpdateDto> GetCurrent()
        {
            var find = await _repository.FirstOrDefaultAsync(x => x.UserId == CurrentUser.Id);

            if (find == null)
            {
                return new PartnerCreateOrUpdateDto();
            }

            return ObjectMapper.Map<Partner, PartnerCreateOrUpdateDto>(find);
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

        private static (double? lat, double? lng) ConvertGeo(double? inputLat, double? inputLng, MallEnums.LocationType inputType, MallEnums.LocationType outType)
        {
            if (inputLat.HasValue && inputLng.HasValue)
            {
                return (inputType, outType) switch
                {
                    (MallEnums.LocationType.gcj02, MallEnums.LocationType.bd09) => (inputLat.Value, inputLng.Value).GCJ02ToBD09(),
                    (MallEnums.LocationType.bd09, MallEnums.LocationType.gcj02) => (inputLat.Value, inputLng.Value).BD09ToGCJ02(),
                    _ => (inputLat, inputLng)
                };
            }

            return (null, null);
        }
    }

    /// <summary>
    ///     <see cref="Partner" />
    /// </summary>
    public class PartnerCreateOrUpdateDto
    {
        [Required(ErrorMessage = "姓名 必填")]
        [DisplayName("姓名")]
        public string RealName { get; set; }

        [Required(ErrorMessage = "电话 必填")]
        [DisplayName("电话")]
        public string Phone { get; set; }

        [DisplayName("备用电话")] public string PhoneBackup { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }

        [Required(ErrorMessage = "地址 必填")]
        [DisplayName("地址")]
        public string LocationLabel { get; set; }

        public string LocationAddress { get; set; }
        public MallEnums.LocationType LocationType { get; set; }
        [Required(ErrorMessage = "个人介绍 必填")] public string Introducting { get; set; }
    }
}