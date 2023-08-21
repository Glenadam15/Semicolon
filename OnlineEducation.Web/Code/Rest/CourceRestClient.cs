using System.Text.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;

namespace OnlineEducation.Web.Code.Rest
{
    public class CourceRestClient : BaseRestClient
	{
		public dynamic GetCource(int id)
		{
			RestRequest req = new RestRequest($"/Cource/CourceImg/{id}", Method.Get);
			RestResponse res = client.Get(req);
			string msg = res.Content.ToString();

			dynamic result = JObject.Parse(msg);
			return result;
		}
	}
}
