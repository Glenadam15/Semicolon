using Microsoft.EntityFrameworkCore;
using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class RoleRepository : RepositoryBase<Role>
{
    public RoleRepository(RepositoryContext context) : base(context)
    {
        
    }

    public void RoleDelete(int rolId)
    {
        RepositoryContext.Roles.Where(r => r.Id == rolId).ExecuteDelete();
    }
}