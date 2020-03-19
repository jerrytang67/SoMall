using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.ShopManagement.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.ShopManagement.Application
{
    public class ShopAppService : ApplicationService, IShopAppService
    {
        private readonly IRepository<VisitorShop, Guid> _repository;
        private readonly ICurrentTenant _currentTenant;

        public ShopAppService(IRepository<VisitorShop, Guid> shopRepository, ICurrentTenant currentTenant)
        {
            ObjectMapperContext = typeof(ShopManagementModule);
            _repository = shopRepository;
            _currentTenant = currentTenant;
        }

        public async Task<PagedResultDto<VisitorShopDto>> GetListAsync(PagedResultRequestDto input)
        {
            var tenantId = _currentTenant.Id;

            var query = _repository;

            var total = await query.CountAsync();

            var shops = await query.PageBy(input).ToListAsync();

            return new PagedResultDto<VisitorShopDto>(total,
                ObjectMapper.Map<List<VisitorShop>, List<VisitorShopDto>>(shops));
        }

        Task<VisitorShopDto> IShopAppService.GetByShortNameAsync(string shortName)
        {
            throw new NotImplementedException();
        }

        Task<VisitorShopDto> IShopAppService.GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<PagedResultDto<VisitorShopDto>> IShopAppService.GetListAsync(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<VisitorShopDto> GetByShortNameAsync(string shortName)
        {
            var find = await _repository.FirstOrDefaultAsync(x => x.ShortName == shortName);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(VisitorShop), shortName);
            }

            return ObjectMapper.Map<VisitorShop, VisitorShopDto>(find);
        }

        public async Task<VisitorShopDto> GetAsync(Guid id)
        {
            var find = await _repository.GetAsync(id);

            return ObjectMapper.Map<VisitorShop, VisitorShopDto>(find);
        }

        [Authorize]
        public async Task<VisitorShopDto> CreateAsync(VisitorShopCreateOrEditDto input)
        {
            var newEntity = await _repository.InsertAsync(new VisitorShop(GuidGenerator.Create(), input.Name, input.ShortName, input.LogoImage, input.CoverImage)
            {
                Description = input.Description,
                TenantId = _currentTenant.Id
            });

            return ObjectMapper.Map<VisitorShop, VisitorShopDto>(newEntity);
        }

        [Authorize]
        public async Task<VisitorShopDto> UpdateAsync(Guid id, VisitorShopCreateOrEditDto body)
        {
            var find = await _repository.GetAsync(id);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(VisitorShopCreateOrEditDto), body.ShortName);
            }

            find.SetName(body.Name);
            find.SetShortName(body.ShortName);
            find.SetLogoImage(body.LogoImage);
            find.SetCoverImage(body.CoverImage);
            find.SetDescription(body.Description);

            return ObjectMapper.Map<VisitorShop, VisitorShopDto>(find);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var find = await _repository.GetAsync(id);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(VisitorShop));
            }

            await _repository.DeleteAsync(find);
        }
    }
}