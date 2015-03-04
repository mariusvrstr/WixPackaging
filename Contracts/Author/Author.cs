
namespace Spike.Contracts.Author
{
    using System;

    public class Author
    {
        public Guid Id { get; set; }
    
        public string Name { get; set; }

        public DateTime BirthDay {get; set; }
    }
}
