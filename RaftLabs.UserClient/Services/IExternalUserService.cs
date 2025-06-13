using RaftLabs.UserClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaftLabs.UserClient.Services
{
    public interface IExternalUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
