using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeswholesaleClient.JsonModels
{
	public class ProductsResponse
	{
		[JsonProperty(PropertyName = "productId")]
		public string ProductId { get; set; }
		[JsonProperty(PropertyName = "identifier")]
		public string Identifier { get; set; }
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		[JsonProperty(PropertyName = "platform")]
		public string Platform { get; set; }
		[JsonProperty(PropertyName = "quantity")]
		public int Quantity { get; set; }
		[JsonProperty(PropertyName = "images")]
		public IEnumerable<Image> Images { get; set; }
		[JsonProperty(PropertyName = "regions")]
		public IEnumerable<string> Regions { get; set; }
		[JsonProperty(PropertyName = "languages")]
		public IEnumerable<string> Languages { get; set; }
		[JsonProperty(PropertyName = "prices")]
		public IEnumerable<Price> Prices { get; set; }
		[JsonProperty(PropertyName = "releaseDate")]
		public string ReleaseDate { get; set; }
		[JsonProperty(PropertyName = "links")]
		public IEnumerable<Link> Links { get; set; }
	}

	public class Image
	{
		[JsonProperty(PropertyName = "image")]
		public string URL { get; set; }
		[JsonProperty(PropertyName = "format")]
		public string Format { get; set; }
	}

	public class Price
	{
		[JsonProperty(PropertyName = "value")]
		public float Value { get; set; }
		[JsonProperty(PropertyName = "from")]
		public int? From { get; set; }
		[JsonProperty(PropertyName = "to")]
		public int? To { get; set; }
	}

	public class Link
	{
		[JsonProperty(PropertyName = "rel")]
		public string Rel { get; set; }
		[JsonProperty(PropertyName = "href")]
		public string Href { get; set; }
		[JsonProperty(PropertyName = "hreflang")]
		public string Hreflang { get; set; }
		[JsonProperty(PropertyName = "media")]
		public string Media { get; set; }
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }
		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }
		[JsonProperty(PropertyName = "deprecation")]
		public string Deprecation { get; set; }
	}
}
