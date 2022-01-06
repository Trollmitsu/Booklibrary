using System;
using System.Collections.Generic;


#nullable disable

namespace Booklibrary.Model
{
    public partial class Attribute
    {
        public Attribute()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public long? Price { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
