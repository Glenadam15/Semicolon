using Microsoft.EntityFrameworkCore;
using OnlineEducation.Model;

namespace OnlineEducation.Repository;

public class CategoryRepository : RepositoryBase<Category>
{
    public CategoryRepository(RepositoryContext context) : base(context)
    {
        
    }
    
    public void CategoryDelete(int categoryId)
    {
        RepositoryContext.Categories.Where(r => r.Id == categoryId).ExecuteDelete();
    }
}
