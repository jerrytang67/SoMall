using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TT.Abp.ShopManagement.Application.Dtos;
using TT.Abp.WeixinManagement;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace TT.Abp.ShopManagement.Application
{
    public interface IWeixinAppService
    {
    }

    public class WeixinAppService : ApplicationService, IWeixinAppService
    {
        private readonly ICurrentTenant _currentTenant;

        public WeixinAppService(ICurrentTenant currentTenant)
        {
            ObjectMapperContext = typeof(WeixinManagementModule);
            _currentTenant = currentTenant;
        }

        public async Task<object> Code2Session(WeChatMiniProgramAuthenticateModel loginModel)
        {
            return await Task.FromResult<object>(null);
        }


        public async Task<string> GetAccessToken(string appid)
        {
            return await Task.FromResult("");
        }
    }
}