

namespace Spike.Model.Author
{
    using System;
    using System.Collections.Generic;
    using Contracts.Author;
    using System.Linq;
    using Waldos;
    
    public class AuthorProviderStub : IAuthorProvider
    {
        private static IEnumerable<Author> _author;

        private static  IEnumerable<Author> Authors 
        {
            get { return _author ?? (_author = AuthorWaldo.PrepareSampleAuthors()); }
        }


        public IEnumerable<Author> GetAllAuthors()
        {
            return Authors;
        }

        public Author GetAuthorById(Guid id)
        {
            return Authors.FirstOrDefault(auth => auth.Id == id);
        }
    }
}
