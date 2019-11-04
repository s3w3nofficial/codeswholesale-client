using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeswholesaleClient.JsonModels
{
	public class AccountInfo
	{
		[JsonProperty(PropertyName = "fullName")]
		public string FullName { get; set; }
		[JsonProperty(PropertyName = "email")]
		public string Email { get; set; }
		[JsonProperty(PropertyName = "currentBalance")]
		public float CurrentBalance { get; set; }
		[JsonProperty(PropertyName = "currentCredit")]
		public float CurrentCredit { get; set; }
		[JsonProperty(PropertyName = "totalToUse")]
		public float TotalToUse { get; set; }
		[JsonProperty(PropertyName = "links")]
		public IEnumerable<Link> Links { get; set; }
	}
}
