using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TT.Abp.Weixin.Application
{
    public interface IPayAppService
    {
    }

    public class PayAppService : ApplicationService, IPayAppService
    {
    }
}