using Newtonsoft.Json.Linq;

namespace TT.Abp.Mall.Application.Products
{
    public interface IHaveSchema
    {
        JToken Schema { get; set; }
    }
}