namespace LibraryMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LibraryMVC.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryMVC.DataAccess.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryMVC.DataAccess.LibraryContext context)
        {
            //Book instance
            Book book = new Book
            {
                Condition = "Mint",
                IsRented = true,
                Loans = new List<Loan>()
            };
            Author author = new Author
            {
                Name = "John Doe",
                Nation = "SE",
                IsAlive = false,
                HasNobelPrize = true,
                BookInformations = new List<BookInformation>()
            };
            BookInformation bookinformation = new BookInformation
            {
                Title = "Sample Title",
                ISBN = "000-001",
                Description = "Description...",
                Category = Category.Romance,
                PublishedYear = 1111,
                Position = "Shelf",
                Authors = new List<Author>(),
                Books = new List<Book>()
            };
            Loan loan = new Loan
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddMonths(3),
                IsReturned = false,
                Books = new List<Book>()
            };
            LoanTaker loantaker = new LoanTaker
            {
                Name = "Some Loaner",
                MembershipNumber = "12",
                Contact = "somemail@client.com",
                Loans = new List<Loan>()
            };
            //Mapping - data
            book.BookInformation = bookinformation;
            bookinformation.Books.Add(book);

            bookinformation.Authors.Add(author);
            author.BookInformations.Add(bookinformation);

            book.Loans.Add(loan);
            loan.Books.Add(book);

            loan.LoanTaker = loantaker;
            loantaker.Loans.Add(loan);

            //Add to db
            context.LoanTakers.Add(loantaker);
            context.SaveChanges();


            /*
            context.Database.ExecuteSqlCommand("Book_Insert @Condition, @IsRented, @BookInformationID",
            new SqlParameter { ParameterName = "@Condition", Value = "Near Mint" },
            new SqlParameter { ParameterName = "@IsRented", Value = 0 },
            new SqlParameter("@BookInformationID", 1)
            
            );
             */
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
