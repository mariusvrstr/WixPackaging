
namespace Spike.Contracts.Author
{
    using System.Collections.Generic;
    using System;

    public interface IAuthorProvider
    {
        IEnumerable<Author> GetAllAuthors();

        Author GetAuthorById(Guid id);
    }
}