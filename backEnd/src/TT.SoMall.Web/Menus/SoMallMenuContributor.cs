using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using TT.SoMall.Localization.SoMall;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace TT.SoMall.Menus
{
    public class SoMallMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!SoMallConsts.IsMultiTenancyEnabled)
            {
                ApplicationMenuItem administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<SoMallResource>>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem("SoMall.Home", l["Menu:Home"], "/"));
        }
    }
}
