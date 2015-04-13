
namespace Spike.Web.Models
{
    using System.Collections.Generic;
    using Contracts.Author;

    public class HomeModel: ModelBase
    {
        public IEnumerable<Author> Authors { get; set; }
        public string Environment { get; set; }
    }
}