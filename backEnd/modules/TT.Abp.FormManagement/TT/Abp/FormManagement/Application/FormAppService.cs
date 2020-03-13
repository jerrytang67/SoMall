using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Settings;

namespace TT.Abp.FormManagement.Application
{
    public class FormAppService : ApplicationService, IFormAppService
    {
        private readonly ISettingProvider _setting;

        public FormAppService(ISettingProvider setting)
        {
            _setting = setting;
        }
    }
}