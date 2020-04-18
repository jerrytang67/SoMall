using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Partners;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Mall.Application.Partners
{
    public interface IPartnerAppService
    {
        Task<PartnerDto> GetAsync(Guid userId);
        Task<PagedResultDto<PartnerDto>> GetListAsync(MallRequestDto input);
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
    }
}