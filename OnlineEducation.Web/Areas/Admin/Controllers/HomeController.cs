using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Role() => View();
        public IActionResult Category() => View();

    }
}
