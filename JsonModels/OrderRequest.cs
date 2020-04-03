using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeswholesaleClient.JsonModels
{
    public class OrderRequest
    {
        [JsonProperty(PropertyName = "products")]
        public IEnumerable<OrderRequstProduct> Products { get; set; }
    }

    public class OrderRequstProduct
    {
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}
