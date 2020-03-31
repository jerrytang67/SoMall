using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TT.Abp.Shops.Application;
using TT.Core.Extensions;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;

namespace TT.Abp.OssManagement.Application
{
    public class OssAppService : ApplicationService, IOssAppService
    {
        private readonly ISettingProvider _setting;
        private readonly IConfiguration _configuration;

        public OssAppService(ISettingProvider setting, IConfiguration configuration)
        {
            _setting = setting;
            _configuration = configuration;
        }

        public async Task<object> GetConfig()
        {
            var UploadHost = await _setting.GetOrNullAsync(OssManagementSettings.UploadHost);
            var BucketName = await _setting.GetOrNullAsync(OssManagementSettings.BucketName);
            var DomainHost = await _setting.GetOrNullAsync(OssManagementSettings.DomainHost);
            var AccessId = await _setting.GetOrNullAsync(OssManagementSettings.AccessId);
            return new
            {
                UploadHost, BucketName, DomainHost, AccessId
            };
        }


        public async Task<object> GetSignature(string data)
        {
            var password = await _setting.GetOrNullAsync(OssManagementSettings.AccessKey);

            if (password.IsNullOrEmptyOrWhiteSpace())
            {
                throw new UserFriendlyException("Oss AccessKey is Empty");
            }

            var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(password.GetMd5()));
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return await Task.FromResult(new {signature = Convert.ToBase64String(hashBytes)});
        }

        public async Task<object> Test()
        {
            var bucketName = await _setting.GetOrNullAsync(OssManagementSettings.BucketName);
            var domain = await _setting.GetOrNullAsync(OssManagementSettings.DomainHost);
            var pwd = await _setting.GetOrNullAsync(OssManagementSettings.AccessKey);
            var username = await _setting.GetOrNullAsync(OssManagementSettings.AccessId);

            var _bucketName = _configuration["Settings:OssManagement.BucketName"];
            var _domain = _configuration["Settings:OssManagement.DomainHost"];
            var _pwd = _configuration["Settings:OssManagement.AccessKey"];
            var _username = _configuration["Settings:OssManagement.AccessId"];
            return new
            {
                appseting = new
                {
                    bucketName,
                    domain,
                    pwd,
                    username
                },
                consul = new
                {
                    _bucketName,
                    _domain,
                    _pwd,
                    _username
                }
            };
        }
    }
}