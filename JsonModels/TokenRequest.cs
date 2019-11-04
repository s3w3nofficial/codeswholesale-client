using Newtonsoft.Json;

namespace CodeswholesaleClient.JsonModels
{
	public class TokenRequest
	{
		[JsonProperty(PropertyName = "grant_type")]
		public string GrantType { get; set; }
		[JsonProperty(PropertyName = "client_secret")]
		public string ClientSecret { get; set; }
		[JsonProperty(PropertyName = "client_id")]
		public string ClientId { get; set; }
	}
}
