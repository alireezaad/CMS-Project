using CMS.ModelLayer;

namespace CMS.RepositoryLayer
{
    class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(CMSContext context) : base(context)
        {
        }
    }
}
