using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TT.Abp.VisitorManagement.Application.Dtos;
using TT.Abp.VisitorManagement.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Application
{
    public interface IVisitorLogAppService : IApplicationService
    {
        Task<ListResultDto<VisitorLogDto>> GetListAsync();

        Task<VisitorLogDto> GetAsync(Guid id);

        Task<VisitorLogDto> CreateAsync(CreateVisitorLogDto input);

        Task DeleteAsync(Guid id);
    }

    public class VisitorLogAppService : ApplicationService, IVisitorLogAppService
    {
        private readonly IRepository<VisitorLog, Guid> _repository;
        private readonly ICurrentTenant _currentTenant;

        public VisitorLogAppService(IRepository<VisitorLog, Guid> shopRepository, ICurrentTenant currentTenant)
        {
            ObjectMapperContext = typeof(VisitorManagementModule);
            _repository = shopRepository;
            _currentTenant = currentTenant;
        }

        public async Task<ListResultDto<VisitorLogDto>> GetListAsync()
        {
            var result = await _repository.GetListAsync();

            return new ListResultDto<VisitorLogDto>(
                ObjectMapper.Map<List<VisitorLog>, List<VisitorLogDto>>(result));
        }

        public Task<VisitorLogDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<VisitorLogDto> CreateAsync(CreateVisitorLogDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}