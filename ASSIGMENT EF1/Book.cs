using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGMENT_EF1
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int NumberOfPages { get; set; }
        public int PublishedYear { get; set; }
        public bool IsInStock { get; set; }

        // Foreign Key Convention
        public int CategoryId { get; set; }

        // Navigation Properties
        public Category Category { get; set; } = null!;
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
