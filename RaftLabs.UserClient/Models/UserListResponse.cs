using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaftLabs.UserClient.Models
{
    public class UserListResponse
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Pages { get; set; }
        public List<UserDto> Data { get; set; }
    }
}
