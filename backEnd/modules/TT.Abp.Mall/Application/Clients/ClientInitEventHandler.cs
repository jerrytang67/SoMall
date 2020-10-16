using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using TT.Abp.Mall.Application.Clients.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Users;

namespace TT.Abp.Mall.Application.Clients
{
    public class ClientInitEvent
    {
        public ClientInitEvent(ClientInitRequestDto inputData)
        {
            InputData = inputData;
        }

        public ClientInitRequestDto InputData { get; set; }
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
}