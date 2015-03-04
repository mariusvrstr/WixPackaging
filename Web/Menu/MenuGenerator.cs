
namespace Spike.Web.Menu
{
    using System.Collections.Generic;

    public class MenuGenerator
    {
        public static IEnumerable<MenuItem> GenerateMenu()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem {Name = "Home", Link = "Home/index"},
                new MenuItem {Name = "Link 2", Link = "Home/index"},
                new MenuItem {Name = "Link 3", Link = "Home/index"}
            };

            return menuItems;
        }
    }
}