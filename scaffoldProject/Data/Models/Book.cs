using System;
using System.Collections.Generic;

namespace scaffoldProject.Data.Models
{
    public partial class Book
    {
        public Book()
        {
            Genres = new HashSet<Genre>();
        }

        public int BookId { get; set; }
        public string? Title { get; set; }
        public int? Year { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author? Author { get; set; }
        public virtual BookDetail? BookDetail { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}
