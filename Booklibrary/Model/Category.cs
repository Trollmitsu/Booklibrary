using System;
using System.Collections.Generic;

#nullable disable

namespace Booklibrary.Model
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
