using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SafeboardConsoleClient.Services.WebApi
{
    class ApiClient : IApiClient
    {
        private const string _baseRoot = "https://localhost:44305";
        private readonly HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetServerStatusAsync()
        {
            var response = await _client.GetAsync(_baseRoot + "/api/APIStatus");
            if (response.IsSuccessStatusCode)
                return "Scan service was started.";
            else
                return "Scan service was stopped.";
        }

        public async Task<string> CreateScanTaskAsync(string directoryPath)
        {
            var response = await _client.PostAsync(_baseRoot + "/api/Scan", new StringContent(""));
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string[]> GetScanTaskStatusAsync(int taskId)
        {
            var response = await _client.GetAsync(_baseRoot + "/api/Scan/" + taskId);
            if(response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());
            else
                return new string[] { await response.Content.ReadAsStringAsync() };
        }
    }
}
