using SkyUnityCore.Dto;
using SkyUnityCore.Entities;
using SkyUnityCore.Repositories;
using System.Threading.Tasks;

namespace SkyUnityServer.Services
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(UserDto user);
        Task<bool> ExistAsync(string name);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _userRepository.ExistNameAsync(name);
        }

        public async Task<bool> RegisterAsync(UserDto user)
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
            };

            await _userRepository.Insert(newUser);

            return true;
        }
    }
}