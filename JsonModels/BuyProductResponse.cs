using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeswholesaleClient.JsonModels
{
	public class BuyProductResponse
	{
		[JsonProperty(PropertyName = "codeType")]
		public string  CodeType { get; set; }
		[JsonProperty(PropertyName = "code")]
		public string Code { get; set; }
		[JsonProperty(PropertyName = "links")]
		public IEnumerable<Link> Links { get; set; }
	}
}
