using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class QuestionRepository : RepositoryBase<Question>
{
    public QuestionRepository(RepositoryContext context) : base(context)
    {
        
    }
}