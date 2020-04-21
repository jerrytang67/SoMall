using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TT.Abp.AppManagement.Domain;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.AppManagement.Application
{
    public interface IAppAppService : ICrudAppService<AppDto, Guid, PagedAndSortedResultRequestDto, AppCreateOrUpdateDto, AppCreateOrUpdateDto>
    {
    }

    public class AppAppService : CrudAppService<App, AppDto, Guid, PagedAndSortedResultRequestDto, AppCreateOrUpdateDto, AppCreateOrUpdateDto>
    {
        public AppAppService(IRepository<App, Guid> repository) : base(repository)
        {
            base.GetListPolicyName = AppManagementPermissions.Apps.Default;
            base.CreatePolicyName = AppManagementPermissions.Apps.Create;
            base.UpdatePolicyName = AppManagementPermissions.Apps.Update;
            base.DeletePolicyName = AppManagementPermissions.Apps.Delete;
        }
    }


    /// <summary>
    /// <see cref="App"/>
    /// </summary>
    public class AppDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ClientName { get; set; }

        public Dictionary<string, string> Value { get; set; }

         public  string ProviderName { get;  set; }

         public  string ProviderKey { get;  set; }
    }

    public class AppCreateOrUpdateDto
    {
        [Required] public string Name { get; set; }

        [Required] public string ClientName { get; set; }
    }
}