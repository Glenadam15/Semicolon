using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Web.Code.Rest;

namespace OnlineEducation.Web.Areas.Cource.Controllers
{
	[Area("Cource")]
	public class CourceController : Controller
	{
		public IActionResult CourceImg(int id)
		{
			CourceRestClient client = new CourceRestClient();
			dynamic result = client.GetCource(id);

			bool success = result.success;
			if (success)
			{
				ViewBag.Cource = result.data;
			}
			return View();
		}
	}
}
