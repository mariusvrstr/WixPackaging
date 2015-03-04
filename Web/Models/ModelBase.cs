
namespace Spike.Web.Models
{
    using Menu;

    using System.Collections.Generic;

    public class ModelBase
    {
        public IEnumerable<MenuItem> MenuItems { get; set; } 
    }
}