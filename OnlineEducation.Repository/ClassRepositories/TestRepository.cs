using Microsoft.EntityFrameworkCore;
using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class TestRepository : RepositoryBase<Test>
{
    public TestRepository(RepositoryContext context) : base(context)
    {
        
    }
    
}