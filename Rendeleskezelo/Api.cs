using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rendeleskezelo
{
    public class Api
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public Api(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _apiKey = apiKey;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("HOTCAKES", apiKey);
        }

        public ApiResponse<List<OrderDTO>> OrdersFindAll()
        {
            string endpoint = $"orders?key={_apiKey}";
            HttpResponseMessage response = _client.GetAsync(endpoint).Result;

            if (!response.IsSuccessStatusCode)
            {
                string errorContent = response.Content.ReadAsStringAsync().Result;
                MessageBox.Show($"API hiba: {response.StatusCode}\n\n{errorContent}");
                return new ApiResponse<List<OrderDTO>> { Content = null };
            }

            string json = response.Content.ReadAsStringAsync().Result;

            var parsed = JsonSerializer.Deserialize<ApiResponse<List<OrderDTO>>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return parsed ?? new ApiResponse<List<OrderDTO>> { Content = null };
        }
    }

    public class ApiResponse<T>
    {
        public T Content { get; set; }
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
    }
}
