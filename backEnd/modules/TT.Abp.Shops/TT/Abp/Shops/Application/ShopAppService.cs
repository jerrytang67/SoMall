using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TT.Abp.Shops.Application.Dtos;
using TT.Abp.Shops.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.Shops.Application
{
    public class ShopAppService : ApplicationService, IShopAppService
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly IRepository<Shop, Guid> _repository;

        public ShopAppService(IRepository<Shop, Guid> shopRepository, ICurrentTenant currentTenant)
        {
            ObjectMapperContext = typeof(ShopModule);
            _repository = shopRepository;
            _currentTenant = currentTenant;
        }

        Task<ShopDto> IShopAppService.GetByShortNameAsync(string shortName)
        {
            throw new NotImplementedException();
        }

        Task<ShopDto> IShopAppService.GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<PagedResultDto<ShopDto>> IShopAppService.GetListAsync(PagedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        public async Task<ShopDto> CreateAsync(VisitorShopCreateOrEditDto input)
        {
            var newEntity = await _repository.InsertAsync(new Shop(GuidGenerator.Create(), input.Name, input.ShortName, input.LogoImage, input.Description, _currentTenant.Id)
            {
                CoverImage = input.CoverImage
            });

            return ObjectMapper.Map<Shop, ShopDto>(newEntity);
        }

        [Authorize]
        public async Task<ShopDto> UpdateAsync(Guid id, VisitorShopCreateOrEditDto body)
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

            return ObjectMapper.Map<Shop, ShopDto>(find);
        }

        [Authorize]
        public async Task DeleteAsync(Guid id)
        {
            var find = await _repository.GetAsync(id);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(Shop));
            }

            await _repository.DeleteAsync(find);
        }

        public async Task<PagedResultDto<ShopDto>> GetListAsync(PagedResultRequestDto input)
        {
            var query = _repository;

            var total = await query.CountAsync();

            var shops = await query.PageBy(input).ToListAsync();

            return new PagedResultDto<ShopDto>(total,
                ObjectMapper.Map<List<Shop>, List<ShopDto>>(shops));
        }

        public async Task<ShopDto> GetByShortNameAsync(string shortName)
        {
            var find = await _repository.FirstOrDefaultAsync(x => x.ShortName == shortName);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(Shop), shortName);
            }

            return ObjectMapper.Map<Shop, ShopDto>(find);
        }

        public async Task<ShopDto> GetAsync(Guid id)
        {
            var find = await _repository.GetAsync(id);

            return ObjectMapper.Map<Shop, ShopDto>(find);
        }
    }
}