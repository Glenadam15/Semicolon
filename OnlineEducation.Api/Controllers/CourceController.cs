using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using OnlineEducation.Model;
using OnlineEducation.Repository;

namespace OnlineEducation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourceController : BaseController
	{
        public CourceController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache) { }

        [HttpGet("GetAllCources")]
        public dynamic GetAllCources()
        {
	        List<Cource> items = repo.CourceRepository.FindAll().ToList<Cource>();
	        return new
	        {
		        success = true,
		        data = items
	        };
        }


        //[Authorize(Roles ="Admin, Instructor")]
        [HttpPost("Save")]
        public dynamic Save([FromBody] dynamic model)
        {
	        dynamic json = JObject.Parse(model.GetRawText());

	        Cource item = new Cource()
	        {
		        Id = json.Id,
		        Name = json.Name,
		        CategoryId = json.CategoryId,
		        Description = json.Description,
	        };

	        if (item.Id > 0)
		        repo.CourceRepository.Update(item);
	        else
	        {
				repo.CourceRepository.Create(item);
			}

	        repo.SaveChanges();

	        cache.Remove("GetAllCources");

	        return new
	        {
		        success = true
	        };
        }

        //[Authorize(Roles = "Admin, Instructor")]
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

	        repo.CourceRepository.CourceDelete(id);
	        return new
	        {
		        success = true
	        };
        }

	}
}
