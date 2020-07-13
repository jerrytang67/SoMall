using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using TT.Abp.Mall.Domain.Comments;
using Volo.Abp.Linq;


namespace TT.Abp.Mall.Application.Comments
{
    public interface ICommentAppService : ICrudAppService<CommentDto, Guid, MallRequestDto, CommentCreateOrUpdateDto, CommentCreateOrUpdateDto>
    {
        Task<PagedResultDto<CommentDto>> GetPublishListAsync(MallRequestDto input);
    }

    public class CommentAppService :
        CrudAppService<Comment, CommentDto, Guid, MallRequestDto, CommentCreateOrUpdateDto, CommentCreateOrUpdateDto>,
        ICommentAppService
    {
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;

        public CommentAppService(
            IRepository<Comment, Guid> repository,
            IAsyncQueryableExecuter asyncQueryableExecuter 
            ) : base(repository)
        {
            _asyncQueryableExecuter = asyncQueryableExecuter;
        }

        [Authorize]
        public override async Task<CommentDto> CreateAsync(CommentCreateOrUpdateDto input)
        {
            var entity = MapToEntity(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }

        [Authorize]
        public override async Task<CommentDto> UpdateAsync(Guid id, CommentCreateOrUpdateDto input)
        {
            //await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);

            if (entity.CreatorId != CurrentUser.Id)
            {
                throw new UserFriendlyException("NotYours");
            }

            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            MapToEntity(input, entity);
            await Repository.UpdateAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }


        protected override IQueryable<Comment> CreateFilteredQuery(MallRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                    .WhereIf(input.State.HasValue, x => x.Status == input.State)
                    .WhereIf(input.ShopId.HasValue, x => x.ShopId == input.ShopId)
                    .WhereIf(input.SpuId.HasValue, x => x.ShopId == input.SpuId)
                    .WhereIf(input.SkuId.HasValue, x => x.ShopId == input.SkuId)
                ;
        }

        public override Task<PagedResultDto<CommentDto>> GetListAsync(MallRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public async Task<PagedResultDto<CommentDto>> GetPublishListAsync(MallRequestDto input)
        {
            var query = base.CreateFilteredQuery(input);

            var totalCount = await query.CountAsync();

            query = query.OrderBy(input.Sorting ?? "id desc");

            query = query.PageBy(input);

            var entities = await _asyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<CommentDto>(
                totalCount,
                entities.Select(MapToGetListOutputDto).ToList()
            );
        }
    }

    /// <summary>
    /// <see cref="Comment"/>
    /// </summary>
    public class CommentDto : CreationAuditedEntityDto<Guid>
    {
        public string BuyerName { get; set; }

        public string BuyerAvatar { get; set; }

        public string Content { get; set; }

        public int Level { get; set; }

        public int Status { get; set; }

        public Guid SpuId { get; set; }

        public Guid? SkuId { get; set; }

        public Guid? ShopId { get; set; }
    }

    public class CommentCreateOrUpdateDto
    {
        public string Content { get; set; }

        public Guid SpuId { get; set; }

        public Guid? SkuId { get; set; }

        public Guid? ShopId { get; set; }
    }
}