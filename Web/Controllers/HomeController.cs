
namespace Spike.Web.Controllers
{
    using System.Web.Mvc;
    using Model;
    using Menu;
    using Models;
    using Utilities;

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var provider = ProviderFactory.CreateAuthorProvider();

            SettingManager.ResetSettings();

            var model = new HomeModel
            {
                MenuItems = MenuGenerator.GenerateMenu(),
                Authors = provider.GetAllAuthors(),
                Environment = SettingManager.Instance.Environment
            };

            return View(model);
        }
    }
}