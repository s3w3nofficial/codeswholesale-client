using CodeswholesaleClient.JsonModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeswholesaleClient
{
    //variables constructors
    public partial class Client
    {
        HttpClient client;

        public Client(Uri endpoint, string client_id, string client_secret)
        {
            client = new HttpClient();
            client.BaseAddress = endpoint;
            var token = GetTokenAsync(new TokenRequest() { GrantType = "client_credentials", ClientId = client_id, ClientSecret = client_secret });
            token.Wait();
            if (token.Result != null)
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Result.AccessToken);
        }
    }

    //GET
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

    //POST
    public partial class Client
    {
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

        public async Task<BuyProductResponse> BuyProductAsync(string productId)
        {
            var resp = await client.PostAsync($"/v1/orders?productId={productId}", new StringContent("", Encoding.UTF8, "application/json"));
            if (resp.IsSuccessStatusCode)
                return JObject.Parse(await resp.Content.ReadAsStringAsync()).ToObject<BuyProductResponse>();
            return null;
        }
    }
}
