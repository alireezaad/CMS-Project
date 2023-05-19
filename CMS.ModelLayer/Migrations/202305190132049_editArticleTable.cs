namespace CMS.ModelLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editArticleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "category_CategoryId" });
            RenameColumn(table: "dbo.Articles", name: "category_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Articles", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            AlterColumn("dbo.Articles", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Articles", name: "CategoryId", newName: "category_CategoryId");
            CreateIndex("dbo.Articles", "category_CategoryId");
            AddForeignKey("dbo.Articles", "category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
