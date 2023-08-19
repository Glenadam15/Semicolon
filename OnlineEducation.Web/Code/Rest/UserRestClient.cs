using System.Text.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;

namespace OnlineEducation.Web.Code.Rest
{
    public class UserRestClient
    {

        private string BASE_API_URI = "https://localhost:7068/api";

        public dynamic Login(string username, string password)
        {
            RestClient client = new RestClient(BASE_API_URI, configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));

            RestRequest req = new RestRequest("/Auth/Login", Method.Post);
            req.AddJsonBody(new
            {
                Username = username,
                Password = password
            });

            RestResponse resp = client.Post(req);
            string msg = resp.Content.ToString();
            dynamic result = JObject.Parse(msg);
            return result;
        }
    }
}
