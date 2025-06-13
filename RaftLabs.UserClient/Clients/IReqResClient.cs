using RaftLabs.UserClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaftLabs.UserClient.Clients
{
   public interface IReqResClient
    {
        Task<SingleUserResponse> GetUserByIdAsync(int userId);
        Task<UserListResponse> GetUsersByPageAsync(int pageNumber);
    }
}
