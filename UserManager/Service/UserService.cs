using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using UserManager.Data.Model;
using UserManager.Data.Repository;
using UserManager.Models;

namespace UserManager.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAccessRoleService _accessRoleService;

        public UserService(
            IUserRepository userRepository,
            IAuthenticationService authenticationService,
            IAccessRoleService accessRoleService,
            IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _accessRoleService = accessRoleService;
            _passwordHasher = passwordHasher;
        }

        public async Task CreateUserAsync(string username, string password, int roleId)
        {
            if (await _userRepository.GetUserByUsernameAsync(username) is not null)
            {
                throw new Exception("User with given username already exists.");
            }

            // 2. Creat user (generate unique ID) and Persist to DB
            var user = new User
            {
                Username = username,
                Password = password,
                AccessRoleId = roleId,
            };
            user.Password = _passwordHasher.HashPassword(user, password);

            await _userRepository.AddUserAsync(user);
            
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<List<UserViewModel>> SearchAsync(string query)
        {
            var users = await _userRepository.SearchUsersAsync(query);

            List<UserViewModel> result = new List<UserViewModel>();

            foreach (var user in users)
            {
                result.Add(
                    new UserViewModel
                    {
                        Id = user.UserId,
                        Username = user.Username,
                        AccessRole = _accessRoleService.GetRoleById(user.AccessRoleId).Role
                    }
                );
            }

            return result;

        }

        public async Task UpdateUserAsync(User newData)
        {
            await _userRepository.UpdateUserAsync(newData);
        }
    }
}
