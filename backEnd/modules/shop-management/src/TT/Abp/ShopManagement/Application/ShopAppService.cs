using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.ShopManagement.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.ShopManagement.Application
{
    public class ShopAppService : ApplicationService, IShopAppService
    {
        private readonly IRepository<Shop, Guid> _repository;

        public ShopAppService(IRepository<Shop, Guid> shopRepository)
        {
            ObjectMapperContext = typeof(ShopManagementModule);
            _repository = shopRepository;
        }


        public async Task<ListResultDto<ShopDto>> GetListAsync()
        {
            var shops = await _repository.GetListAsync();

            return new ListResultDto<ShopDto>(
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

        public async Task<ShopDto> CreateAsync(CreateShopDto input)
        {
            var newEntity = await _repository.InsertAsync(new Shop(GuidGenerator.Create(), input.Name, input.ShortName, input.CoverImage)
            {
                Description = input.Description
            });

            return ObjectMapper.Map<Shop, ShopDto>(newEntity);
        }

        public async Task<ShopDto> UpdateAsync(Guid id, UpdateShopDto body)
        {
            var find = await _repository.GetAsync(id);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(Shop), body.ShortName);
            }

            //ObjectMapper.Map(input, find);

            find.SetName(body.Name);
            find.SetShortName(body.ShortName);
            find.SetCoverImage(body.CoverImage);
            find.SetDescription(body.Description);

            return ObjectMapper.Map<Shop, ShopDto>(find);
        }

        public async Task DeleteAsync(Guid id)
        {
            var find = await _repository.GetAsync(id);

            if (find == null)
            {
                throw new EntityNotFoundException(typeof(Shop));
            }

            await _repository.DeleteAsync(find);
        }
    }
}