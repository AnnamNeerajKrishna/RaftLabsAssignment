using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using RaftLabs.UserClient.Clients;
using RaftLabs.UserClient.Models;
using RaftLabs.UserClient.Services;
using Xunit;

namespace RaftLabs.UserClient.Tests.Services
{
    public class ExternalUserServiceTests
    {
        private readonly Mock<IReqResClient> _mockClient;
        private readonly ExternalUserService _service;

        public ExternalUserServiceTests()
        {
            _mockClient = new Mock<IReqResClient>();
            _service = new ExternalUserService(_mockClient.Object);
        }

        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser()
        {
            // Arrange
            var expectedUser = new UserDto { Id = 2, First_Name = "Janet", Last_Name = "Weaver" };

            _mockClient
                .Setup(c => c.GetUserByIdAsync(2))
                .ReturnsAsync(new SingleUserResponse { Data = expectedUser });

            // Act
            var result = await _service.GetUserByIdAsync(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Janet", result.First_Name);
        }

        [Fact]
        public async Task GetAllUsersAsync_ReturnsAllUsers()
        {
            // Arrange
            var usersPage1 = new UserListResponse
            {
                Page = 1,
                Total_Pages = 2,
                Data = new List<UserDto>
                {
                    new UserDto { Id = 1, First_Name = "George" }
                }
            };

            var usersPage2 = new UserListResponse
            {
                Page = 2,
                Total_Pages = 2,
                Data = new List<UserDto>
                {
                    new UserDto { Id = 2, First_Name = "Janet" }
                }
            };

            _mockClient
                .Setup(c => c.GetUsersByPageAsync(1))
                .ReturnsAsync(usersPage1);
            _mockClient
                .Setup(c => c.GetUsersByPageAsync(2))
                .ReturnsAsync(usersPage2);

            // Act
            var result = await _service.GetAllUsersAsync();

            // Assert
            Assert.Equal(2, result.Count);
        }
    }
}
