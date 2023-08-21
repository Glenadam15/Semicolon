using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Web.Code.Filters;

namespace OnlineEducation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthActionFilter]
    public class HomeController : Controller
    {
	    public IActionResult Index() => View();
        public IActionResult Role() => View();
        public IActionResult Category() => View();

    }
}
