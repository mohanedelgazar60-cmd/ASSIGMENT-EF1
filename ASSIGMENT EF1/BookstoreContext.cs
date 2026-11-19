using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASSIGMENT_EF1;
using Microsoft.EntityFrameworkCore;

public class BookstoreContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Using SQL Server with LocalDB
        optionsBuilder.UseSqlServer(@"Server=.;Database=ReadMoreBooksDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}