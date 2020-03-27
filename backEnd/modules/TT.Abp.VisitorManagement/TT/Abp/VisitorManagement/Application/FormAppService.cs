using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Shops;
using TT.Abp.Shops.Application.Dtos;
using TT.Abp.Shops.Domain;
using TT.Abp.VisitorManagement.Application.Dtos;
using TT.Abp.VisitorManagement.Domain;
using TT.Extensions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.VisitorManagement.Application
{
    public class FormAppService : ApplicationService, IFormAppService
    {
        private readonly IVisitorShopLookupService _vShopLookupService;
        private readonly IRepository<Form, Guid> _repository;
        private readonly IRepository<VisitorShop, Guid> _shopRepository;
        private readonly IRepository<VisitorLog, Guid> _visitorLogRepository;

        private readonly ICurrentTenant _currentTenant;

        public FormAppService(
            IVisitorShopLookupService vShopLookupService,
            IRepository<Form, Guid> formRepository,
            IRepository<VisitorShop, Guid> shopRepository,
            IRepository<VisitorLog, Guid> visitorLogRepository,
            ICurrentTenant currentTenant)
        {
            ObjectMapperContext = typeof(VisitorManagementModule);
            _vShopLookupService = vShopLookupService;
            _repository = formRepository;
            _shopRepository = shopRepository;
            _visitorLogRepository = visitorLogRepository;
            // _shopFormRepository = shopFormRepository;
            _currentTenant = currentTenant;
        }

        public async Task<ListResultDto<FormDto>> GetListAsync()
        {
            var result = await _repository.GetListAsync();

            return new ListResultDto<FormDto>(
                ObjectMapper.Map<List<Form>, List<FormDto>>(result));
        }

        public async Task<FormDto> GetAsync(Guid id)
        {
            var find = await _repository.GetAsync(id);

            return ObjectMapper.Map<Form, FormDto>(find);
        }

        [Authorize]
        public async Task<FormDto> CreateAsync(FormCreateOrEditDto input)
        {
            var newEntity = await _repository.InsertAsync(new Form(GuidGenerator.Create(),
                input.Title,
                input.Description,
                _currentTenant.Id
            ));
            return ObjectMapper.Map<Form, FormDto>(newEntity);
        }

        [Authorize]
        public async Task<FormDto> UpdateAsync(Guid id, FormCreateOrEditDto body)
        {
            var find = await _repository.GetAsync(id);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(Form), body.Title);
            }

            find.SetTitle(body.Title);
            find.SetDescription(body.Description);
            find.Theme = body.Theme;

            return ObjectMapper.Map<Form, FormDto>(find);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            if (await _repository.Include(x => x.ShopForms).Where(x => x.Id == id).Select(x => x.ShopForms).CountAsync() > 0)
                throw new UserFriendlyException("已有商户应用了这个表单,不能删除");
            await _repository.DeleteAsync(id);
        }

        /// <summary>
        /// 取得使用这个表单的商家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<VisitorShopDto>> GetShops(Guid id)
        {
            var find = await _repository.Include(x => x.ShopForms).FirstOrDefaultAsync(x => x.Id == id);

            var shopids = find.ShopForms.Select(x => x.ShopId);

            var shops = await _shopRepository.Where(x => shopids.Contains(x.Id)).ToListAsync();

            return ObjectMapper.Map<List<VisitorShop>, List<VisitorShopDto>>(shops);
        }


        public async Task<object> GetShopForm(string id)
        {
            var shop_id = id.FromShortString();

            var form = await _repository
                .Include(x => x.ShopForms)
                .Include(x => x.FormItems)
                .Where(x => x.ShopForms.Any(y => y.ShopId == shop_id) && x.ShopForms.Any(y => y.FormId == new Guid("4de02c90-c97c-5c7e-d3e4-39f3f28f2e90"))).FirstOrDefaultAsync();

            if (form == null)
                throw new UserFriendlyException("NotFind");

            var shop = await _shopRepository.FirstOrDefaultAsync(x => x.Id == shop_id);

            if (shop == null)
                throw new UserFriendlyException("NotFind");

            if (this.CurrentUser.IsAuthenticated)
            {
                var visitorLog = await _visitorLogRepository.OrderByDescending(x => x.CreationTime).FirstOrDefaultAsync(x => x.LeaveTime == null &&
                                                                                                                             x.ShopId == shop_id &&
                                                                                                                             x.FormId == form.Id &&
                                                                                                                             x.CreatorId == this.CurrentUser.Id);
                if (visitorLog != null)
                {
                    var v = ObjectMapper.Map<VisitorLog, VisitorLogDto>(visitorLog);
                    v.Html = $"<h2>{shop.ShortName}</h2>{shop.Description}";
                    return new {visitorLog = v};
                }
            }

            var formDto = ObjectMapper.Map<Form, FormDto>(form);
            formDto.FormItems = formDto.FormItems.OrderBy(x => x.Sort).ToList();

            return new {shop = ObjectMapper.Map<VisitorShop, VisitorShopDto>(shop), form = formDto};
        }

        [HttpPost]
        public async Task AddShop(FormAddShopRequestDto input)
        {
            var find = await _vShopLookupService.FindByIdAsync(input.ShopIds[0]);

            var form = await _repository
                .Include(x => x.ShopForms)
                .FirstOrDefaultAsync(x => x.Id == input.FromId);
            if (form == null)
            {
                throw new UserFriendlyException("NotFind");
            }

            var shops = await _shopRepository.Where(x => input.ShopIds.Contains(x.Id)).ToListAsync();
            foreach (var shop in shops)
            {
                if (form.ShopForms.All(x => x.ShopId != shop.Id))
                {
                    form.ShopForms.Add(new ShopForm(form.Id, shop.Id));
                }
            }

            await Task.CompletedTask;
        }

        public class FormAddShopRequestDto : ShopSyncRequestDto
        {
            public Guid FromId { get; set; }
        }
    }
}