using System.Security.Cryptography.X509Certificates;
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
	    var courceLessons = RepositoryContext.CourceLessons.Where(x=>x.CourceId == courceId);
        List<Lesson> lessons = new List<Lesson>();
        foreach (var cl in courceLessons)
        {
	         var lesson = RepositoryContext.Lessons.SingleOrDefault(x => x.Id == cl.LessonId);

	         if (lesson != null)
	         {
		         lessons.Add(lesson);
	         }
        }
        return lessons;
    }
}