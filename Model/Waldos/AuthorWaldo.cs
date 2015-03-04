
namespace Spike.Model.Waldos
{
    using System.Collections.Generic;
    using Builders;
    using Contracts.Author;

    public class AuthorWaldo
    {
        public static IEnumerable<Author> PrepareSampleAuthors()
        {
            return new List<Author>
            {
                new AuthorBuilder().CliveCusler().Build(),
                new AuthorBuilder().WilburSmith().Build(),
                new AuthorBuilder().AnnRice().Build()
            };
        }
    }
}
