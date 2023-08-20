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
	public class TestController : BaseController
	{
		public TestController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
		{
		}

		[HttpGet("AllTests")]
		public dynamic AllTests()
		{
			List<Test> items = repo.TestRepository.FindAll().ToList<Test>();
			return new
			{
				success = true,
				data = items
			};
		}

		[HttpGet("{courceId}")]
		public dynamic Get(int courceId)
		{
			List<Test> item = repo.TestRepository.FindByCondition(a => a.CourceId == courceId).ToList<Test>();
			return new
			{
				success = true,
				data = item
			};
		}

	}
}
