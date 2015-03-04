
namespace Spike.Web.Controllers
{
    using System.Web.Mvc;
    using Model;
    using Menu;
    using Models;

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var provider = ProviderFactory.CreateAuthorProvider();

            var model = new AuthorsModel
            {
                MenuItems = MenuGenerator.GenerateMenu(),
                Authors = provider.GetAllAuthors()
            };

            return View(model);
        }
    }
}