using SkyUnityCore.Dto;
using SkyUnityCore.Entities;
using SkyUnityCore.Repositories;

namespace SkyUnityServer.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserDto user);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterAsync(UserDto user)
        {
            //await _userRepository.Insert(new User
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Email = user.Email,
            //    Name = user.Name,
            //    Password = user.Password,
            //});

            return true;
        }
    }
}