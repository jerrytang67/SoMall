using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.Mall.Application.Addresses.Dtos;
using TT.Abp.Mall.Application.Clients.Dtos;
using TT.Abp.Weixin.Application.Dtos;
using Volo.Abp.Application.Dtos;

namespace TT.Abp.Mall.Application.Clients
{
    public interface IClientAppService
    {
        Task<object> Init(ClientInitRequestDto input);
        Task<object> MiniAuth(WeChatMiniProgramAuthenticateModel loginModel);
        Task<ListResultDto<AddressDto>> GetUserAddressListAsync();
        Task<object> SumbitOrder(ProductOrderRequestDto input);
        Task<object> PayNotifyUrl(string appName, [FromBody] TenPayNotifyXml input);
    }
}