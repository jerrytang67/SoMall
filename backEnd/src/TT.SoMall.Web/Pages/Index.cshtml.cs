using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace TT.SoMall.Web.Pages
{
    public class IndexModel : SoMallPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}