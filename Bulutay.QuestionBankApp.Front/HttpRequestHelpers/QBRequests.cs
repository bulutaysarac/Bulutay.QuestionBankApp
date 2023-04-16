using System.Net.Http.Headers;
using System.Text.Json;

namespace Bulutay.QuestionBankApp.Front.HttpRequestHelpers
{
    public static class QBRequests
    {
        public static async Task<List<IModel>> GetAllAsync<IModel>(IHttpClientFactory httpClientFactory, string url, string token)
        {
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<IModel>>(jsonData, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return result;
            }
            return null;
        }

        public static async Task<IModel> Get<IModel>(IHttpClientFactory httpClientFactory, string url, int id, string token)
        {
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"{url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<IModel>(jsonData, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                return result;
            }
            return default;
        }

        public static async Task<HttpResponseMessage> CreateAsync(IHttpClientFactory httpClientFactory, StringContent content, string url, string token)
        {
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PostAsync(url, content);
            return response;
        }

        public static async Task<HttpResponseMessage> UpdateAsync(IHttpClientFactory httpClientFactory, StringContent content, string url, string token)
        {
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.PutAsync(url, content);
            return response;
        }

        public static async Task<HttpResponseMessage> RemoveAsync(IHttpClientFactory httpClientFactory, string url, int id, string token)
        {
            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.DeleteAsync($"{url}/{id}");
            return response;
        }
    }
}
