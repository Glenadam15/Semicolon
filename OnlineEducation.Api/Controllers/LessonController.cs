using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using OnlineEducation.Model;
using OnlineEducation.Repository;
using static OnlineEducation.Model.Enums;

namespace OnlineEducation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LessonController : BaseController
	{
		public LessonController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
		{
		}

		[HttpGet("Lessons/{courceId}")]
		public dynamic Lessons(int courceId)
		{
			List<Lesson> lesson = repo.LessonRepository.LessonByCourceId(courceId);

			return new
			{
				success = true,
				data = lesson
			};
		}

		//[Authorize(Roles = "Admin,Instructor")]
		[HttpDelete("{id}")]
		public dynamic Delete(int id)
		{
			repo.LessonRepository.Delete(id);
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

			Lesson item = new Lesson()
			{
				Id = json.Id,
				Name = json.Name,
				Description = json.Description
			};

			if (item.Id > 0)
				repo.LessonRepository.Update(item);
			else
			{
				foreach (var lessonId in json.Id)
				{
					item.CourceLessons.Add(new CourceLesson() { LessonId = lessonId });
				}
				repo.LessonRepository.Create(item);
			}

			repo.SaveChanges();

			return new
			{
				success = true
			};
		}


	}
}
