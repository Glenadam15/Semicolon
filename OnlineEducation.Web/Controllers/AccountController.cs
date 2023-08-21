using Microsoft.AspNetCore.Mvc;
using OnlineEducation.Web.Code.Rest;
using OnlineEducation.Web.Code;
using OnlineEducation.Web.Models;

namespace OnlineEducation.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult AccessLogin(LoginModel model)
        {

            UserRestClient client = new UserRestClient();
            dynamic result = client.Login(model.Username, model.Password);

            bool success = result.success;

            if (success)
            {
                Repo.Session.Username = model.Username;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Role = (string)result.role;

				if (Repo.Session.Role == "Admin")
					return RedirectToAction("Index", "Home", new { area = "Admin" });
				else
					return RedirectToAction("Index", "Home");
			}
            else
            {
	            ViewBag.LoginError = (string)result.message;
                return View("Login");
            }
        }

        public IActionResult Logout()
        {
	        Repo.Session.Username = "";
	        Repo.Session.Token = "";
	        Repo.Session.Role = "";

	        return RedirectToAction("Index", "Home");
        }
	}
}
