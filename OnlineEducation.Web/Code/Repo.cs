namespace OnlineEducation.Web.Code
{
    public class Repo
    {
        public static class Session
        {

            public static string? Email
            {
                get
                {
                    string email = (new HttpContextAccessor()).HttpContext.Session.GetString("Email");
                    return email;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Email", value ?? "");
                }
            }
            public static string? Token
            {
                get
                {
                    string token = (new HttpContextAccessor()).HttpContext.Session.GetString("Token");
                    return token;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Token", value ?? "");
                }
            }
            public static string? Role
            {
                get
                {
                    string rol = (new HttpContextAccessor()).HttpContext.Session.GetString("Role");
                    return rol;
                }
                set
                {
                    (new HttpContextAccessor()).HttpContext.Session.SetString("Role", value ?? "");
                }
            }
        }
    }
}
