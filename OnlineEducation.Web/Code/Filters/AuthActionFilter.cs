using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace OnlineEducation.Web.Code.Filters
{
	public class AuthActionFilter : ActionFilterAttribute, IAuthorizationFilter
	{
		public string Role;
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (!string.IsNullOrEmpty(Role))
			{
				bool isAuthorized = Role.Split(',').Contains(Repo.Session.Role);
				if (!isAuthorized)
					context.Result = new UnauthorizedResult();
			}
			else if (string.IsNullOrEmpty(Repo.Session.Username))
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
