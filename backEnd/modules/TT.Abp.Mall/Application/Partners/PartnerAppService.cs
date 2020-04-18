using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Mall.Domain.Partners;
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
}