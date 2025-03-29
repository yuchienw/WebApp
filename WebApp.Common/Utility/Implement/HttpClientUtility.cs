using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApp.Common.Utility.Interface;

namespace WebApp.Common.Utility.Implement
{
    public class HttpClientUtility : IHttpClientUtility
    {
        private readonly HttpClient _httpClient;

        public HttpClientUtility(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse(response);
        }

        public async Task<string> PostAsync(string url, object data)
        {
            var dict = ((IFormCollection)data).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
            var json = JsonConvert.SerializeObject(dict);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            return await HandleResponse(response);
        }

        public async Task<bool> PutAsync(string url, object data)
        {
            var dict = ((IFormCollection)data).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
            var json = JsonConvert.SerializeObject(dict);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            return JsonConvert.DeserializeObject<bool>(await HandleResponse(response));
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            return JsonConvert.DeserializeObject<bool>(await HandleResponse(response));
        }

        private async Task<string> HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            var content = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status {response.StatusCode}: {content}");
        }
    }
}
