﻿using System;
using System.Collections.Generic;

namespace scaffoldProject.Data.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int GenreId { get; set; }
        public string? GenreName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
