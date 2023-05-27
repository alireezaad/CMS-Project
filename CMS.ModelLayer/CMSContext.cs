using System.Data.Entity;

namespace CMS.ModelLayer
{
    public class CMSContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Comment> comments { get; set; }

        //public System.Data.Entity.DbSet<CMSArticle.Views.ViewModel.ArticleViewModel> ArticleViewModels { get; set; }

        //public System.Data.Entity.DbSet<CMSArticle.Views.ViewModel.ArticleViewModel> ArticleViewModels { get; set; }
    }
}
