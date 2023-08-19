using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class CommentRepository : RepositoryBase<Comment>
{
    public CommentRepository(RepositoryContext context) : base(context)
    {
        
    }
}