using System.Data.Entity;
using LibraryMVC.Models;
namespace LibraryMVC.DataAccess
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DefaultConnection") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookInformation> BookInformations { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanTaker> LoanTakers { get; set; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //One-To-Many
            modelBuilder.Entity<Book>()
                .HasRequired<BookInformation>(book => book.BookInformation)
                .WithMany(bi => bi.Books)
                .HasForeignKey(book => book.BookInformationID);
            //Many-To-Many
            modelBuilder.Entity<Book>()
                .HasMany<Loan>(book => book.Loans)
                .WithMany(loan => loan.Books)
                .Map(booksloans =>
                {
                    booksloans.MapLeftKey("BookRefID");
                    booksloans.MapRightKey("LoanRefID");
                    booksloans.ToTable("BookLoan");
                });
        }
         */
    }
}