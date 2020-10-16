using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using TT.SoMall.Localization;
using TT.SoMall.MultiTenancy;
using Volo.Abp.Account.Localization;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace TT.SoMall.Menus
{
    public class SoMallMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public SoMallMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<SoMallResource>>();

            // context.Menu.Items.Insert(0, new ApplicationMenuItem("SoMall.Home", l["Menu:Home"], "/"));

            context.Menu.AddItem(
                new ApplicationMenuItem("Shop", l["Menu:Shop"])
                    .AddItem(
                        new ApplicationMenuItem("Shops", l["Menu:Shop"], url: "/Shops")
                    )
            );

#if DEBUG
            context.Menu.AddItem(
                new ApplicationMenuItem("admin", "管理后台",url:"http://192.168.3.50:4200/")
            );
#else
            context.Menu.AddItem(
                new ApplicationMenuItem("admin", "管理后台",url:"/admin")
            );
#endif


            return Task.CompletedTask;
        }

        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<SoMallResource>>();
            var accountStringLocalizer = context.ServiceProvider.GetRequiredService<IStringLocalizer<AccountResource>>();
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            if (currentUser.IsAuthenticated)
            {
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountStringLocalizer["ManageYourProfile"], $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog",
                    order: 1000, null, "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", l["Logout"], url: "/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));
            }

            return Task.CompletedTask;
        }
    }
}