using CMS.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.RepositoryLayer
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(CMSContext context) : base(context)
        {
        }
    }
}
