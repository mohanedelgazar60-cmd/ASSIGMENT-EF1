using Microsoft.EntityFrameworkCore;

namespace ASSIGMENT_EF1
{
    internal class Program
    {
      static void Main(string[] args)
            {
                using var context = new BookstoreContext();

                // Ensure database is created based on conventions
                context.Database.EnsureDeleted(); // Optional: clears old DB for clean test runs
                context.Database.EnsureCreated();
                Console.WriteLine("Database created successfully using EF Core Conventions!");

                // Seed sample data if database is empty
                if (!context.Categories.Any())
                {
                    var category = new Category
                    {
                        Name = "Technology",
                        Description = "Books about software development and IT.",
                        IsActive = true
                    };

                    var author = new Author
                    {
                        FirstName = "Jane",
                        LastName = "Doe",
                        Email = "jane.doe@example.com",
                        Biography = "Software engineer and technical writer.",
                        DateOfBirth = new DateTime(1985, 6, 15)
                    };

                    var book = new Book
                    {
                        Title = "Entity Framework Core in Action",
                        ISBN = "978-1-61729-something",
                        Price = 49.99m,
                        NumberOfPages = 450,
                        PublishedYear = 2024,
                        IsInStock = true,
                        Category = category,
                        Authors = new List<Author> { author }
                    };

                    context.Books.Add(book);
                    context.SaveChanges();
                    Console.WriteLine("Sample data seeded successfully!");
                }

                // Query and display data
                Console.WriteLine("\n--- Bookstore Inventory ---");
                var books = context.Books
                    .Include(b => b.Category)
                    .Include(b => b.Authors)
                    .ToList();

                foreach (var b in books)
                {
                    Console.WriteLine($"Title: {b.Title}");
                    Console.WriteLine($"Category: {b.Category.Name} (Active: {b.Category.IsActive})");
                    Console.WriteLine($"Authors: {string.Join(", ", b.Authors.Select(a => $"{a.FirstName} {a.LastName}"))}");
                    Console.WriteLine($"Price: ${b.Price} | In Stock: {b.IsInStock}");
                    Console.WriteLine(new string('-', 30));
                }
      }
    } 
}

