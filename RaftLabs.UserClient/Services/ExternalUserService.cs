using RaftLabs.UserClient.Clients;
using RaftLabs.UserClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaftLabs.UserClient.Services
{
    public class ExternalUserService : IExternalUserService
    {
        private readonly IReqResClient _client;

        public ExternalUserService(IReqResClient client)
        {
            _client = client;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            try
            {
                var response = await _client.GetUserByIdAsync(id);

                if (response?.Data == null)
                {
                    Console.WriteLine($"User with ID {id} not found.");
                    return null; // Or return a default object
                }

                return response.Data;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error occurred: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return null;
            }
        }


        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var allUsers = new List<UserDto>();
            int page = 1;

            try
            {
                while (true)
                {
                    var result = await _client.GetUsersByPageAsync(page);

                    if (result?.Data == null || result.Data.Count == 0)
                        break;

                    allUsers.AddRange(result.Data);

                    if (page >= result.Total_Pages)
                        break;

                    page++;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP error while fetching users: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            return allUsers;
        }

    }
}
