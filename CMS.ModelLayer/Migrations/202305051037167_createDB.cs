namespace CMS.ModelLayer.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                {
                    ArticleId = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 50),
                    Content = c.String(nullable: false),
                    ImageName = c.String(nullable: false, maxLength: 100),
                    RegisterDate = c.DateTime(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    Like = c.Int(nullable: false),
                    Visit = c.Int(nullable: false),
                    AdminId = c.Int(nullable: false),
                    category_CategoryId = c.Int(),
                    user_UserId = c.Int(),
                })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Categories", t => t.category_CategoryId)
                .ForeignKey("dbo.Users", t => t.user_UserId)
                .Index(t => t.category_CategoryId)
                .Index(t => t.user_UserId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 20),
                    ImageName = c.String(),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    Family = c.String(nullable: false, maxLength: 30),
                    Phonenumber = c.String(nullable: false, maxLength: 15),
                    Password = c.String(nullable: false, maxLength: 15),
                    RegisterDate = c.DateTime(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    CommentId = c.Int(nullable: false, identity: true),
                    FullName = c.String(nullable: false, maxLength: 20),
                    Email = c.String(nullable: false, maxLength: 40),
                    Content = c.String(nullable: false),
                    RegisterDate = c.DateTime(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    article_ArticleId = c.Int(),
                })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Articles", t => t.article_ArticleId)
                .Index(t => t.article_ArticleId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Comments", "article_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.Articles", "category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "article_ArticleId" });
            DropIndex("dbo.Articles", new[] { "user_UserId" });
            DropIndex("dbo.Articles", new[] { "category_CategoryId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
