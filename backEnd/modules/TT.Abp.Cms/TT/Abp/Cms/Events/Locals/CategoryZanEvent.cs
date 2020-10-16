using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using TT.Abp.Cms.Domain;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;

namespace TT.Abp.Cms.Events.Locals
{
    public class CategoryEventData
    {
        public CategoryEventData(Category category)
        {
            Category = category;
        }

        public Category Category { get; }
    }

    public class CategoryZanEventDataHandle : ILocalEventHandler<CategoryEventData>, ITransientDependency
    {
        public async Task HandleEventAsync(CategoryEventData eventData)
        {
            Log.Warning(JsonConvert.SerializeObject(eventData.Category));

            await Task.CompletedTask;
        }
    }
}