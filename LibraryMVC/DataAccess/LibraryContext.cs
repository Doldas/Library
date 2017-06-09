using System.Data.Entity;

namespace LibraryMVC.DataAccess
{
    public class LibraryContext : DbContext
    {
        public DbSet<Models.Book> Books { get; set; }
        public LibraryContext() : base("DefaultConnection") { }
    }
}