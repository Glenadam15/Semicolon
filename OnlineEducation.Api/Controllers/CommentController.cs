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
	public class CommentController : BaseController
	{
		public CommentController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
		{
		}

		[HttpGet("GetAllComments")]
		public dynamic GetAllComments()
		{
			List<Comment> items = repo.CommentRepository.FindAll().ToList<Comment>();
			return new
			{
				success = true,
				data = items
			};
		}
	}
}
