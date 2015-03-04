
namespace Spike.Model.Builders
{
    using Contracts.Author;
    using System;

    public class AuthorBuilder : Author
    {
        public AuthorBuilder() : this(Guid.NewGuid()) { }

        public AuthorBuilder(Guid id)
        {
            this.Id = id;
        }

        public AuthorBuilder CliveCusler()
        {
            this.Name = "Clive Cusler";
            this.BirthDay = new DateTime(1931,07,15);
            return this;
        }

        public AuthorBuilder WilburSmith()
        {
            this.Name = "Wilbur Smith";
            this.BirthDay = new DateTime(1933, 01, 09);
            return this;
        }

        public AuthorBuilder AnnRice()
        {
            this.Name = "Ann RIce";
            this.BirthDay = new DateTime(1941, 09, 04);
            return this;
        }

        public Author Build()
        {
            return this;
        }

    }
}
