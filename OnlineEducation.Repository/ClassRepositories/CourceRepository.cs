using Microsoft.EntityFrameworkCore;
using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class CourceRepository : RepositoryBase<Cource>
{
    public CourceRepository(RepositoryContext context) : base(context)
    {
        
    }

    public void Delete(int courceId)
    {
	    // Delete From tbCource Where Id={CourceId}
	    RepositoryContext.CourceLessons.Where(c => c.CourceId == courceId).ExecuteDelete();
	    RepositoryContext.Cources.Where(x => x.Id == courceId).ExecuteDelete();
    }

    public Cource CourceById(int id)
    {
	    Cource cource = (from c in RepositoryContext.Cources.Include(a => a.CourceImg)
		    where c.Id == id
		    select c).SingleOrDefault<Cource>();
	    return cource;
    }
}