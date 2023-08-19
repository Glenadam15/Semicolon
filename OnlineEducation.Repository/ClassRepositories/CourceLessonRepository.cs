using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class CourceLessonRepository : RepositoryBase<CourceLesson>
{
    public CourceLessonRepository(RepositoryContext context) : base(context)
    {
        
    }
}