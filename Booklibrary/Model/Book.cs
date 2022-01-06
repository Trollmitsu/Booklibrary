using System;
using System.Collections.Generic;

#nullable disable

namespace Booklibrary.Model
{
    public partial class Book
    {
        public long Id { get; set; }
        public long? AuthorId { get; set; }
        public long? CategoriesId { get; set; }
        public long? AttributesId { get; set; }
        public string BookName { get; set; }


        public virtual Attribute Attributes { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Categories { get; set; }
    }
}
