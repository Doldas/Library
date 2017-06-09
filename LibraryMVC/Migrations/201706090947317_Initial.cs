namespace LibraryMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nation = c.String(maxLength: 2),
                        IsAlive = c.Boolean(nullable: false),
                        HasNobelPrize = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookInformations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category = c.Int(nullable: false),
                        Description = c.String(),
                        Position = c.String(),
                        PublishedYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Condition = c.String(nullable: false),
                        IsRented = c.Boolean(nullable: false),
                        BookInformationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookInformations", t => t.BookInformationID, cascadeDelete: true)
                .Index(t => t.BookInformationID);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        LoanTakerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LoanTakers", t => t.LoanTakerID, cascadeDelete: true)
                .Index(t => t.LoanTakerID);
            
            CreateTable(
                "dbo.LoanTakers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MembershipNumber = c.String(),
                        Name = c.String(),
                        Contact = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookInformationAuthors",
                c => new
                    {
                        BookInformation_ID = c.Int(nullable: false),
                        Author_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookInformation_ID, t.Author_ID })
                .ForeignKey("dbo.BookInformations", t => t.BookInformation_ID, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.BookInformation_ID)
                .Index(t => t.Author_ID);
            
            CreateTable(
                "dbo.LoanBooks",
                c => new
                    {
                        Loan_ID = c.Int(nullable: false),
                        Book_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Loan_ID, t.Book_ID })
                .ForeignKey("dbo.Loans", t => t.Loan_ID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_ID, cascadeDelete: true)
                .Index(t => t.Loan_ID)
                .Index(t => t.Book_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "LoanTakerID", "dbo.LoanTakers");
            DropForeignKey("dbo.LoanBooks", "Book_ID", "dbo.Books");
            DropForeignKey("dbo.LoanBooks", "Loan_ID", "dbo.Loans");
            DropForeignKey("dbo.Books", "BookInformationID", "dbo.BookInformations");
            DropForeignKey("dbo.BookInformationAuthors", "Author_ID", "dbo.Authors");
            DropForeignKey("dbo.BookInformationAuthors", "BookInformation_ID", "dbo.BookInformations");
            DropIndex("dbo.LoanBooks", new[] { "Book_ID" });
            DropIndex("dbo.LoanBooks", new[] { "Loan_ID" });
            DropIndex("dbo.BookInformationAuthors", new[] { "Author_ID" });
            DropIndex("dbo.BookInformationAuthors", new[] { "BookInformation_ID" });
            DropIndex("dbo.Loans", new[] { "LoanTakerID" });
            DropIndex("dbo.Books", new[] { "BookInformationID" });
            DropTable("dbo.LoanBooks");
            DropTable("dbo.BookInformationAuthors");
            DropTable("dbo.LoanTakers");
            DropTable("dbo.Loans");
            DropTable("dbo.Books");
            DropTable("dbo.BookInformations");
            DropTable("dbo.Authors");
        }
    }
}
