
using Microsoft.EntityFrameworkCore;
using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class LessonRepository : RepositoryBase<Lesson>
{
    public LessonRepository(RepositoryContext context) : base(context)
    {
    }

    public List<Lesson> LessonByCourceId(int courceId)
    {
	    List<Lesson> items = (from l in RepositoryContext.Lessons
		    join c in RepositoryContext.CourceLessons on l.Id equals c.LessonId
		    where c.CourceId == courceId
		    select l).ToList<Lesson>();
	    return items;
	}
}