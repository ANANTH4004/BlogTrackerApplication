namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminInfoes",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.BlogInfoes",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                        BlogUrl = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.EmpInfoes", t => t.Email, cascadeDelete: true)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.EmpInfoes",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                        Passcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogInfoes", "Email", "dbo.EmpInfoes");
            DropIndex("dbo.BlogInfoes", new[] { "Email" });
            DropTable("dbo.EmpInfoes");
            DropTable("dbo.BlogInfoes");
            DropTable("dbo.AdminInfoes");
        }
    }
}
