using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class AnswerRepository : RepositoryBase<Answer>
{
    public AnswerRepository(RepositoryContext context) : base(context)
    {
        
    }
}