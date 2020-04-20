using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Weixin.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Weixin.Application
{
    public interface IWechatUserAppService : IApplicationService
    {
        Task<PagedResultDto<WechatUserinfo>> GetListAsync(PagedAndSortedResultRequestDto input);
    }


    public class WechatUserAppService : ApplicationService
    {
        private readonly IRepository<WechatUserinfo> _wechatUserRepository;

        public WechatUserAppService(IRepository<WechatUserinfo> wechatUserRepository)
        {
            _wechatUserRepository = wechatUserRepository;
        }

        public virtual async Task<PagedResultDto<WechatUserinfo>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _wechatUserRepository.AsQueryable();

            var totalCount = await query.CountAsync();

            query = query.OrderBy("CreationTime desc");

            query = query.PageBy(input);

            var result = await query.ToListAsync();

            return new PagedResultDto<WechatUserinfo>(totalCount, result);
        }
    }
}