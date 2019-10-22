using System;
using System.Collections.Generic;
using System.Text;
using TT.SoMall.Localization;
using Volo.Abp.Application.Services;

namespace TT.SoMall
{
    /* Inherit your application services from this class.
     */
    public abstract class SoMallAppService : ApplicationService
    {
        protected SoMallAppService()
        {
            LocalizationResource = typeof(SoMallResource);
        }
    }
}
