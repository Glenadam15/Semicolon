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

    public Cource CourceById(int courceId)
    {
	    Cource cource = (from c in RepositoryContext.Cources.Include(a => a.CourceImgs)
		    where c.Id == courceId
		    select c).SingleOrDefault<Cource>();
	    return cource;
    }
}