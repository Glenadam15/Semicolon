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
	        List<Cource> items;

			if (!cache.TryGetValue("GetAllCources", out items))
			{
				items = repo.CourceRepository.FindAll().ToList<Cource>();
				cache.Set("GetAllCources", items, DateTimeOffset.UtcNow.AddSeconds(300));
			}
			return new
	        {
		        success = true,
		        data = items
	        };
        }

        //[Authorize(Roles = "Admin,Instructor")]
        [HttpDelete("{id}")]
        public dynamic Delete(int id)
        {
	        repo.CourceRepository.Delete(id);
	        return new
	        {
		        success = true
	        };
        }

        //[Authorize(Roles = "Admin,Instructor")]
        [HttpPost("Save")]
        public dynamic Save([FromBody] dynamic model)
        {
	        dynamic json = JObject.Parse(model.GetRawText());

	        Cource item = new Cource()
	        {
		        Id = json.Id,
		        Name = json.Name,
				CategoryId = json.CategoryId,
		        Description = json.Description
	        };

	        if (item.Id > 0)
		        repo.CourceRepository.Update(item);
	        else
	        {
		        foreach (var courceId in json.Id)
		        {
			        item.CourceLessons.Add(new CourceLesson() { CourceId = courceId });
		        }
		        repo.CourceRepository.Create(item);
	        }

	        repo.SaveChanges();

	        return new
	        {
		        success = true
	        };
        }

        [HttpGet("CourceImg")]

        public dynamic CourceImg(int id)
        {
	        Cource cource = repo.CourceRepository.CourceById(id);
	        return new
	        {
		        success = true,
				data = cource
	        };

		}




}
}
