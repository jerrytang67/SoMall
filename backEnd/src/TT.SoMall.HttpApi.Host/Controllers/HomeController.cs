using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace TT.SoMall.Controllers
{
    public class HomeController : AbpController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}