
namespace Spike.Web.Models
{
    using System.Collections.Generic;
    using Contracts.Author;
    using Spike.Web.Models;

    public class AuthorsModel: ModelBase
    {
        public IEnumerable<Author> Authors { get; set; }
    }
}