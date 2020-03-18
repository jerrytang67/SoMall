using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.ShopManagement.Domain;
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
        private readonly IRepository<Shop, Guid> _shopRepository;
        private readonly IRepository<Form, Guid> _formRepository;
        private readonly ICurrentTenant _currentTenant;

        public VisitorLogAppService(
            IRepository<VisitorLog, Guid> repository,
            IRepository<Shop, Guid> shopRepository,
            IRepository<Form, Guid> formRepository,
            ICurrentTenant currentTenant
            )
        {
            ObjectMapperContext = typeof(VisitorManagementModule);
            _repository = repository;
            _shopRepository = shopRepository;
            _formRepository = formRepository;
            _currentTenant = currentTenant;
        }

        [Authorize]
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

        [HttpPost]
        public async Task<object> FormSubmit(VisitorFormSumbitRequest input)
        {
            await _repository.InsertAsync(new VisitorLog(Guid.NewGuid(), input.Form.Id, input.Shop?.Id,
                _currentTenant.Id)
            {
                FormJson = JsonConvert.SerializeObject(input.FormItems)
            });

            return await Task.FromResult(input);
        }
    }

    public class VisitorFormSumbitRequest
    {
        public List<FormItemDto> FormItems { get; set; }
        public FormDto Form { get; set; }
        [CanBeNull] public ShopDto Shop { get; set; }
    }
}