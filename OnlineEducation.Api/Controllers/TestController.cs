using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineEducation.Repository;

namespace OnlineEducation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : BaseController
	{
		public TestController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
		{
		}


	}
}
