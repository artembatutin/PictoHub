namespace PictoHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Thread_Id", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "Thread_Id" });
            AddColumn("dbo.Threads", "CommentsCount", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "ThreadId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Boards", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Boards", "Desc", c => c.String(nullable: false));
            AlterColumn("dbo.Threads", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Threads", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Threads", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "Thread_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Thread_Id", c => c.Int());
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Comments", "Author", c => c.String());
            AlterColumn("dbo.Threads", "Author", c => c.String());
            AlterColumn("dbo.Threads", "Content", c => c.String());
            AlterColumn("dbo.Threads", "Title", c => c.String());
            AlterColumn("dbo.Boards", "Desc", c => c.String());
            AlterColumn("dbo.Boards", "Title", c => c.String());
            DropColumn("dbo.Comments", "Date");
            DropColumn("dbo.Comments", "ThreadId");
            DropColumn("dbo.Threads", "CommentsCount");
            CreateIndex("dbo.Comments", "Thread_Id");
            AddForeignKey("dbo.Comments", "Thread_Id", "dbo.Threads", "Id");
        }
    }
}
