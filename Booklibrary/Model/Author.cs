using System;
using System.Collections.Generic;

#nullable disable

namespace Booklibrary.Model
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string AuthorsName { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
