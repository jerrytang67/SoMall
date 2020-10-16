using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using TT.Abp.AppManagement.Apps;
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
        private readonly IAppDefinitionManager _appDefinitionManager;

        public AppAppService(
            IRepository<App, Guid> repository,
            IAppDefinitionManager appDefinitionManager
        ) : base(repository)
        {
            _appDefinitionManager = appDefinitionManager;
            base.GetListPolicyName = AppManagementPermissions.Apps.Default;
            base.CreatePolicyName = AppManagementPermissions.Apps.Create;
            base.UpdatePolicyName = AppManagementPermissions.Apps.Update;
            base.DeletePolicyName = AppManagementPermissions.Apps.Delete;
        }

        protected override IQueryable<App> CreateFilteredQuery(PagedAndSortedResultRequestDto input)
        {
            var query = Repository
                    .WhereIf(CurrentTenant.Id.HasValue, x => x.ProviderName == "T" && x.ProviderKey == CurrentTenant.Id.Value.ToString())
                    .WhereIf(!CurrentTenant.Id.HasValue, x => x.ProviderName == "T" && x.ProviderKey == null)
                ;

            return query;
        }

        public async Task<IReadOnlyList<AppDefinition>> GetPublishList()
        {
            var list = _appDefinitionManager.GetAll();
            return await Task.FromResult(list);
        }
    }


    /// <summary>
    ///     <see cref="App" />
    /// </summary>
    public class AppDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ClientName { get; set; }

        public Dictionary<string, string> Value { get; set; }

        public string ProviderName { get; set; }

        public string ProviderKey { get; set; }
    }

    public class AppCreateOrUpdateDto
    {
        [NotNull] public string Name { get; set; }

        [NotNull] public string ClientName { get; set; }

        [NotNull] public string ProviderName { get; set; }

        [CanBeNull] public string ProviderKey { get; set; }
    }
}