using System.Threading.Tasks;
using Serilog;
using TT.Abp.Mall.Domain.Products;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Uow;

namespace TT.Abp.Mall.Events.Products
{
    public class CommissionChangeEvent
    {
        private readonly ProductSku _productSku;

        public CommissionChangeEvent(ProductSku productSku)
        {
            _productSku = productSku;
        }
    }


    public class CommissionChangeEventHandle : ILocalEventHandler<CommissionChangeEvent>, ITransientDependency
    {
        [UnitOfWork]
        public virtual async Task HandleEventAsync(CommissionChangeEvent eventData)
        {
            Log.Warning("CommissionChangeEventHandle");
            await Task.CompletedTask;
        }
    }
}