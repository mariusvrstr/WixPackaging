
namespace Spike.Model
{
    using Contracts.Author;
    using Author;

    public class ProviderFactory
    {

        public static IAuthorProvider CreateAuthorProvider()
        {
            return new AuthorProviderStub();
        }
    }
}
