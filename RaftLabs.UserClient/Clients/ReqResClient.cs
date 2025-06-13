using RaftLabs.UserClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RaftLabs.UserClient.Clients
{
    public class ReqResClient : IReqResClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ReqResClient(HttpClient httpClient, string apiKey, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;

            if (!_httpClient.DefaultRequestHeaders.Contains("x-api-key"))
            {
                _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }
        }
        public async Task<SingleUserResponse> GetUserByIdAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{userId}");
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Failed to fetch user. Status code: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<SingleUserResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result!;
        }

        public async Task<UserListResponse> GetUsersByPageAsync(int pageNumber)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users?page={pageNumber}");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Failed to fetch users. Status code: {response.StatusCode}");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<UserListResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result!;
        }
    }
}
