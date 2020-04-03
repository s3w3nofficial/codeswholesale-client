using CodeswholesaleClient.JsonModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeswholesaleClient
{
    #region retryhandler
    public class RetryHandler : DelegatingHandler
    {
        private const int _MAXRETRIES = 3;

        public RetryHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        { }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            for (int i = 0; i < _MAXRETRIES; i++)
            {
                response = await base.SendAsync(request, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
            }

            return response;
        }
    }
    #endregion

    #region variables constructors
    public partial class Client
    {
        HttpClient client;

        public Client(Uri endpoint, string client_id, string client_secret)
        {
            client = new HttpClient(new RetryHandler(new HttpClientHandler()));
            client.BaseAddress = endpoint;
            var token = GetTokenAsync(new TokenRequest() { GrantType = "client_credentials", ClientId = client_id, ClientSecret = client_secret });
            token.Wait();
            if (token.Result != null)
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Result.AccessToken);
        }

        public async Task<TokenResponse> GetTokenAsync(TokenRequest request)
        {
            try
            {
                var data = JObject.Parse(JsonConvert.SerializeObject(request).ToString()).ToObject<Dictionary<string, string>>();
                var encodedData = new FormUrlEncodedContent(data);
                var encodedDataString = await encodedData.ReadAsStringAsync();
                var resp = await client.PostAsync("/oauth/token", new StringContent(encodedDataString, Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (resp.IsSuccessStatusCode)
                    return JObject.Parse(await resp.Content.ReadAsStringAsync()).ToObject<TokenResponse>();
                return null;
            }
            catch { return null; }
        }
    }
    #endregion

    #region V1
    #region GET
    public partial class Client
    {
        public async Task<IEnumerable<ProductsResponse>> GetProductsAsync()
        {
            try
            {
                var resp = await client.GetAsync("/v1/products");
                string respString = await resp.Content.ReadAsStringAsync();
                return JObject.Parse(respString)["items"].Select(o => o.ToObject<ProductsResponse>()).ToList();
            }
            catch { return null; }
        }

        public async Task<ProductResponse> GetProductAsync(string id)
        {
            try
            {
                var resp = await client.GetAsync($"/v1/products/{id}");
                string respString = await resp.Content.ReadAsStringAsync();
                return JObject.Parse(respString).ToObject<ProductResponse>();
            }
            catch { return null; }
        }

        public async Task<AccountInfo> GetAccountInfoAsync()
        {
            try
            {
                var resp = await client.GetAsync("v1/accounts/current");
                string respString = await resp.Content.ReadAsStringAsync();
                return JObject.Parse(respString).ToObject<AccountInfo>();
            }
            catch { return null; }
        }
    }
    #endregion

    #region POST
    public partial class Client
    {

        public async Task<BuyProductResponse> BuyProductAsync(string productId)
        {
            var resp = await client.PostAsync($"/v1/orders?productId={productId}", new StringContent("", Encoding.UTF8, "application/json"));
            if (resp.IsSuccessStatusCode)
                return JObject.Parse(await resp.Content.ReadAsStringAsync()).ToObject<BuyProductResponse>();
            return null;
        }
    }
    #endregion
    #endregion

    #region V2
    #region Get
    public partial class Client
    {
        public async Task<OrderResponse> GetOrderById(string orderId)
        {
            var resp = await client.GetAsync($"/v2/orders/{orderId}");
            if (resp.IsSuccessStatusCode)
                return JObject.Parse(await resp.Content.ReadAsStringAsync()).ToObject<OrderResponse>();
            return null;
        }
    }
    #endregion

    #region Post
    public partial class Client
    {
        public async Task<OrderResponse> PostOrderAsync(OrderRequest request)
        {
            var data = JsonConvert.SerializeObject(request).ToString();
            var resp = await client.PostAsync($"/v2/orders", new StringContent(data, Encoding.UTF8, "application/json"));
            if (resp.IsSuccessStatusCode)
                return JObject.Parse(await resp.Content.ReadAsStringAsync()).ToObject<OrderResponse>();
            return null;
        }
    }
    #endregion
    #endregion
}
