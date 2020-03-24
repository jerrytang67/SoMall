using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TT.Abp.VisitorManagement.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.VisitorManagement.Application
{
    public interface IFormAppService : IApplicationService
    {
        Task<ListResultDto<FormDto>> GetListAsync();

        Task<FormDto> GetAsync(Guid id);

        Task<FormDto> CreateAsync(FormCreateOrEditDto input);


        Task<FormDto> UpdateAsync(Guid id, FormCreateOrEditDto body);

        Task DeleteAsync(Guid id);

        Task<List<VisitorShopDto>> GetShops(Guid id);

        Task<object> GetShopForm(string id);
    }
}