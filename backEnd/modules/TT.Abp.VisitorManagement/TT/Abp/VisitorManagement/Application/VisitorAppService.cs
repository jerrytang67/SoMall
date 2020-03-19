using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.ShopManagement.Domain;
using TT.Abp.VisitorManagement.Application.Dtos;
using TT.Abp.VisitorManagement.Domain;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TT.Abp.VisitorManagement.Application
{
    public interface IVisitorLogAppService : IApplicationService
    {
        Task<PagedResultDto<VisitorLogDto>> GetListAsync(VisitorLogRequestDto input);

        Task<VisitorLogDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);
    }

    public class VisitorLogAppService : ApplicationService, IVisitorLogAppService
    {
        private readonly IRepository<VisitorLog, Guid> _repository;
        private readonly IRepository<VisitorShop, Guid> _shopRepository;
        private readonly IRepository<Form, Guid> _formRepository;
        private readonly ICurrentTenant _currentTenant;

        public VisitorLogAppService(
            IRepository<VisitorLog, Guid> repository,
            IRepository<VisitorShop, Guid> shopRepository,
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
        public async Task<PagedResultDto<VisitorLogDto>> GetListAsync(VisitorLogRequestDto input)
        {
            var query = _repository
                .WhereIf(input.FormId.HasValue, x => x.FormId == input.FormId)
                .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId)
                ;

            var total = await query.CountAsync();

            var result = await query.OrderByDescending(x => x.CreationTime).PageBy(input).ToListAsync();

            return new PagedResultDto<VisitorLogDto>(total, ObjectMapper.Map<List<VisitorLog>, List<VisitorLogDto>>(result));

        }

        public Task<VisitorLogDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        [Authorize]
        [HttpPost]
        public async Task<object> FormSubmit(VisitorFormSumbitRequest input)
        {
            var result = await _repository.InsertAsync(new VisitorLog(Guid.NewGuid(), input.Form.Id, input.Shop?.Id,
                _currentTenant.Id)
            {
                FormJson = JsonConvert.SerializeObject(input.FormItems)
            });

            return await Task.FromResult(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<object> Leave(VisitorLogDto input)
        {
            var visitlog = await _repository.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (visitlog == null)
                throw new UserFriendlyException("NotFind");

            visitlog.LeaveTime = DateTimeOffset.Now;

            return new { visitlog.LeaveTime };
        }
    }

    public class VisitorFormSumbitRequest
    {
        public List<FormItemDto> FormItems { get; set; }
        public FormDto Form { get; set; }
        [CanBeNull] public VisitorShopDto Shop { get; set; }
    }


    public class VisitorLogRequestDto : PagedAndSortedResultRequestDto
    {
        public Guid? FormId { get; set; }

        public Guid? ShopId { get; set; }
    }
}