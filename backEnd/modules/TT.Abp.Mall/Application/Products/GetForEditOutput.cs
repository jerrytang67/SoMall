using Newtonsoft.Json.Linq;

namespace TT.Abp.Mall.Application.Products
{
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
}