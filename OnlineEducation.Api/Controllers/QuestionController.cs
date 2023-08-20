using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineEducation.Model;
using OnlineEducation.Repository;
using System.Linq;

namespace OnlineEducation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestionController : BaseController
	{
		public QuestionController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
		{
		}

		[HttpGet("GetQuestionsByTest")]
		public dynamic GetAllQuestions(int testId)
		{
			List<Question> items = repo.QuestionRepository.FindByCondition(x=>x.TestId == testId).ToList<Question>();
			return new
			{
				success = true,
				data = items
			};
		}
	}
}
