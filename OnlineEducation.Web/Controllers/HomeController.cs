using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Web.Models;
using System.Diagnostics;

namespace OnlineEducation.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(){}

	    public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Contact() => View();


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}