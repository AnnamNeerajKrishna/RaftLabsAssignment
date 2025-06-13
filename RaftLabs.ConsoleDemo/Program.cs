using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RaftLabs.UserClient.Clients;
using RaftLabs.UserClient.Services;

namespace RaftLabs.ConsoleDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== RaftLabs User Client Demo ===\n");

            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var apiSettings = configuration.GetSection("ReqResApi").Get<ApiSettings>();

            using var httpClient = new HttpClient();
            // Initialize the API client and service
            var client = new ReqResClient(httpClient, apiSettings.ApiKey, apiSettings.BaseUrl);
            var service = new ExternalUserService(client);

            // Fetch a single user
            Console.WriteLine("Fetching user with ID = 2...");
            var user = await service.GetUserByIdAsync(2);

            if (user != null)
            {
                Console.WriteLine($"User: {user.First_Name} {user.Last_Name} | Email: {user.Email}");
            }
            else
            {
                Console.WriteLine("User not found.");
            }

           

            // Fetch all users
            Console.WriteLine("\nFetching all users...");
            var allUsers = await service.GetAllUsersAsync();

            foreach (var u in allUsers)
            {
                Console.WriteLine($"[{u.Id}] {u.First_Name} {u.Last_Name} - {u.Email}");
            }

            Console.WriteLine("\nDemo complete.");
        }
    }
}
