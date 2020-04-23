using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Volo.Abp.Users;

namespace TT.Abp.Mall.Application.Clients.Dtos
{
    public class ClientInitRequestDto
    {
        public JObject SystemInfo { get; set; }

        [CanBeNull] public ICurrentUser CurrentUser { get; set; }
    }
}
