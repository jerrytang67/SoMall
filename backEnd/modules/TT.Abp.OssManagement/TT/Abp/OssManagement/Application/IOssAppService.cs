using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace TT.Abp.OssManagement.Application
{
    public interface IOssAppService : IApplicationService
    {
        Task<object> GetSignature(string data);
        Task<object> GetConfig();
    }
}