using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.ModelLayer
{
    public class CMSContext:DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<Comment> comments { get; set; }

    }
}
