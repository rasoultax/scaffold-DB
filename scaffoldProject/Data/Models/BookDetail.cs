using System;
using System.Collections.Generic;

namespace scaffoldProject.Data.Models
{
    public partial class BookDetail
    {
        public int DetailId { get; set; }
        public int? BookId { get; set; }
        public int? PublicationYear { get; set; }
        public string? Summary { get; set; }

        public virtual Book? Book { get; set; }
    }
}
