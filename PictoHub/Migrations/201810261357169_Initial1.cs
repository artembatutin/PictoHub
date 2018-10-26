namespace PictoHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Desc = c.String(),
                        Color = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Board = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        Author = c.String(),
                        Color = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Content = c.String(),
                        Color = c.Int(nullable: false),
                        Thread_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.Thread_Id)
                .Index(t => t.Thread_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Thread_Id", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Thread_Id" });
            DropTable("dbo.Comments");
            DropTable("dbo.Threads");
            DropTable("dbo.Boards");
        }
    }
}
