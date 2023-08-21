using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using OnlineEducation.Model;
using OnlineEducation.Repository;

namespace OnlineEducation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    public CategoryController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
    {
    }
    
    [HttpGet("GetAllCategories")]
    public dynamic GetAllCategories()
    {
        List<Category> items;

        if (!cache.TryGetValue("GetAllCategories", out items))
        {
            items = repo.CategoryRepository.FindAll().ToList<Category>();

            cache.Set("GetAllCategories", items, DateTimeOffset.UtcNow.AddSeconds(30));
                
        }
            
        return new
        {
            success = true,
            data = items
        };
    }
    
    [Authorize(Roles = "Admin")]
    [HttpPost("Save")]
    public dynamic Save ([FromBody] dynamic model)
    {
        dynamic json = JObject.Parse(model.GetRawText());

        Category item = new Category()
        {
            Id = json.Id,
            Name = json.Name,
     
        };

        if (item.Id > 0)
            repo.CategoryRepository.Update(item);
        else
            repo.CategoryRepository.Create(item);

        repo.SaveChanges();

        cache.Remove("GetAllCategories");

        return new
        {
            success = true
        };
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("Delete")]
    public dynamic Delete(int id)
    {
        if (id <= 0)
        {
            return new
            {
                success = false,
                message = "Invalid id"
            };
        }

        repo.CategoryRepository.CategoryDelete(id);
        return new
        {
            success = true
        };
    }
    
}