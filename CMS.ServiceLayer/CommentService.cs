using CMS.ModelLayer;

namespace CMS.ServiceLayer
{
    public class CommentService : EntityService<Comment>, ICommentService
    {
        public CommentService(CMSContext context) : base(context)
        {
        }
    }
}
