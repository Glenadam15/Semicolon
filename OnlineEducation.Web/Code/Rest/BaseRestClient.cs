using System.Text.Json;
using RestSharp;
using RestSharp.Serializers.Json;

namespace OnlineEducation.Web.Code.Rest
{
	public class BaseRestClient
	{
		public static string BASE_URL = "https://localhost:7068/api";
		protected RestClient client;

		public BaseRestClient()
		{
			client = new RestClient(BASE_URL, configureSerialization: s => s.UseSystemTextJson(new JsonSerializerOptions { PropertyNamingPolicy = null }));
		}
	}
}
