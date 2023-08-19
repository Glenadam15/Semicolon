using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineEducation.Model;
using OnlineEducation.Repository;

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
		public dynamic Lesson(int courceId)
		{
			List<Lesson> lesson = repo.LessonRepository.LessonByCourceId(courceId);

			return new
			{
				success = true,
				data = lesson
			};
		}
	}
}
