using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

using TT.Abp.AccountManagement.Domain;
using TT.Abp.AccountManagement.Domain.Dtos;

namespace TT.Abp.AccountManagement.Application
{
    public interface IRealNameInfoAppService : IApplicationService
    {
        Task<PagedResultDto<RealNameInfoDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }

    public class RealNameInfoAppService : ApplicationService, IRealNameInfoAppService
    {
        private readonly IRepository<RealNameInfo> _repository;

        public RealNameInfoAppService(
            IRepository<RealNameInfo> repository
        )
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<RealNameInfoDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //await CheckGetListPolicyAsync();

            var query = _repository.AsQueryable();

            var totalCount = await query.CountAsync();

            query = query.OrderBy("creationTime desc");
            query = query.PageBy(input);

            var entities = await query.ToListAsync();

            var list = new PagedResultDto<RealNameInfoDto>(
                totalCount,
                ObjectMapper.Map<List<RealNameInfo>, List<RealNameInfoDto>>(entities)
            );

            return list;
        }
    }
}