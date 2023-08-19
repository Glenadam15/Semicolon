using Microsoft.EntityFrameworkCore;
using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class CourceRepository : RepositoryBase<Cource>
{
    public CourceRepository(RepositoryContext context) : base(context)
    {
        
    }

    public void CourceDelete(int courceid)
    {
	    RepositoryContext.Categories.Where(c => c.Id == courceid).ExecuteDelete();

	}
}