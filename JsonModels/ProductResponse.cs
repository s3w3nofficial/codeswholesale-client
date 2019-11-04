using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeswholesaleClient.JsonModels
{
	public class ProductResponse
	{
		[JsonProperty(PropertyName = "productId")]
		public string ProductId { get; set; }
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		[JsonProperty(PropertyName = "platform")]
		public string Platform { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "prices")]
		public IEnumerable<Price> Prices { get; set; }
        [JsonProperty(PropertyName = "images")]
        public IEnumerable<Image> Images { get; set; }
    }
}
