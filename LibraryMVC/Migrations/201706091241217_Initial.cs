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
                        ISBN = c.String(),
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
                "dbo.BookLoan",
                c => new
                    {
                        BookRefID = c.Int(nullable: false),
                        LoanRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookRefID, t.LoanRefID })
                .ForeignKey("dbo.Books", t => t.BookRefID, cascadeDelete: true)
                .ForeignKey("dbo.Loans", t => t.LoanRefID, cascadeDelete: true)
                .Index(t => t.BookRefID)
                .Index(t => t.LoanRefID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookLoan", "LoanRefID", "dbo.Loans");
            DropForeignKey("dbo.BookLoan", "BookRefID", "dbo.Books");
            DropForeignKey("dbo.Loans", "LoanTakerID", "dbo.LoanTakers");
            DropForeignKey("dbo.Books", "BookInformationID", "dbo.BookInformations");
            DropForeignKey("dbo.BookInformationAuthors", "Author_ID", "dbo.Authors");
            DropForeignKey("dbo.BookInformationAuthors", "BookInformation_ID", "dbo.BookInformations");
            DropIndex("dbo.BookLoan", new[] { "LoanRefID" });
            DropIndex("dbo.BookLoan", new[] { "BookRefID" });
            DropIndex("dbo.BookInformationAuthors", new[] { "Author_ID" });
            DropIndex("dbo.BookInformationAuthors", new[] { "BookInformation_ID" });
            DropIndex("dbo.Loans", new[] { "LoanTakerID" });
            DropIndex("dbo.Books", new[] { "BookInformationID" });
            DropTable("dbo.BookLoan");
            DropTable("dbo.BookInformationAuthors");
            DropTable("dbo.LoanTakers");
            DropTable("dbo.Loans");
            DropTable("dbo.Books");
            DropTable("dbo.BookInformations");
            DropTable("dbo.Authors");
        }
    }
}
