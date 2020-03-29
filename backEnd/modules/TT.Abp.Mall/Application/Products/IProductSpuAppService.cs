using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TT.Abp.Mall.Application.Products.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TT.Abp.Mall.Application.Products
{
    public interface IProductSpuAppService : ICrudAppService<
        ProductSpuDto,
        Guid,
        PagedAndSortedResultRequestDto,
        SpuCreateOrUpdateDto,
        SpuCreateOrUpdateDto>
    {
        Task<GetForEditOutput<SpuCreateOrUpdateDto>> GetForEdit(Guid id);
    }

    public class GetForEditOutput<T> : IHaveSchema
    {
        public GetForEditOutput(T company, JToken schema)
        {
            data = company;
            Schema = schema;
        }

        public T data { get; set; }

        public JToken Schema { get; set; }
    }

    public interface IHaveSchema
    {
        JToken Schema { get; set; }
    }

    public interface ICanSchema
    {
    }
}