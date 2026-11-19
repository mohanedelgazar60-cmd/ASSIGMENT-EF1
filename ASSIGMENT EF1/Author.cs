using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGMENT_EF1
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        // Navigation Property for Many-to-Many relationship with Book
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
