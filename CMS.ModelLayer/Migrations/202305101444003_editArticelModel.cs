namespace CMS.ModelLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editArticelModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "user_UserId", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "user_UserId" });
            RenameColumn(table: "dbo.Articles", name: "user_UserId", newName: "UserId");
            AlterColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "UserId");
            AddForeignKey("dbo.Articles", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Articles", "AdminId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "AdminId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Articles", "UserId", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "UserId" });
            AlterColumn("dbo.Articles", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Articles", name: "UserId", newName: "user_UserId");
            CreateIndex("dbo.Articles", "user_UserId");
            AddForeignKey("dbo.Articles", "user_UserId", "dbo.Users", "UserId");
        }
    }
}
