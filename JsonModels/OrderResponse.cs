using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeswholesaleClient.JsonModels
{
    public class OrderResponse
    {
        [JsonProperty(PropertyName = "orderId")]
        public string OrderId { get; set; }
        [JsonProperty(PropertyName = "clientOrderId")]
        public string ClientOrderId { get; set; }
        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }
        [JsonProperty(PropertyName = "totalPrice")]
        public float TotalPrice { get; set; }
        [JsonProperty(PropertyName = "createdOn")]
        public string CreatedOn { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }

    }

    public class OrderProduct
    {
        [JsonProperty(PropertyName = "productId")]
        public string ProductId { get; set; }
        [JsonProperty(PropertyName = "unitPrice")]
        public int UnitPrice { get; set; }
        [JsonProperty(PropertyName = "codes")]
        public IEnumerable<OrderProductCodes> Codes { get; set; }
        [JsonProperty(PropertyName = "links")]
        public IEnumerable<Link> Links { get; set; }
    }

    public class OrderProductCodes
    {
        [JsonProperty(PropertyName = "code")]
        public string code { get; set; }
        [JsonProperty(PropertyName = "codeId")]
        public string codeId { get; set; }
        [JsonProperty(PropertyName = "codeType")]
        public string codeType { get; set; }
        [JsonProperty(PropertyName = "filename")]
        public string filename { get; set; }
        [JsonProperty(PropertyName = "links")]
        public IEnumerable<Link> Links { get; set; }
    }
}
