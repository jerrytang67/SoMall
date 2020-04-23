using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Users;

namespace TT.Abp.Mall.Application.Clients
{
    public class ClientInitEvent
    {
        public ClientInitRequestDto InputData { get; set; }

        public ClientInitEvent(ClientInitRequestDto inputData)
        {
            InputData = inputData;
        }
    }

    public class ClientInitEventHandler : ILocalEventHandler<ClientInitEvent>, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;

        public ClientInitEventHandler(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public virtual async Task HandleEventAsync(ClientInitEvent eventData)
        {
            if (_currentUser.IsAuthenticated)
            {
                eventData.InputData.CurrentUser = _currentUser;
            }

            Log.Warning(JsonConvert.SerializeObject(eventData.InputData));
            
            await Task.CompletedTask;
        }
    }

    public class ClientInitRequestDto
    {
        public JObject SystemInfo { get; set; }

        public ICurrentUser CurrentUser { get; set; }
    }
}