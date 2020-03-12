using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TT.Abp.ShopManagement.Application;
using TT.Core.Extensions;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;

namespace TT.Abp.OssManagement.Application
{
    public class OssAppService : ApplicationService, IOssAppService
    {
        private readonly ISettingProvider _setting;

        public OssAppService(ISettingProvider setting)
        {
            _setting = setting;
        }

        public async Task<object> GetSignature(string data)
        {
            var password = await _setting.GetOrNullAsync(OssManagementSettings.AccessKey);
            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(password.GetMd5()));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

            return await Task.FromResult(new {signature = Convert.ToBase64String(hashBytes)});
        }
    }
}