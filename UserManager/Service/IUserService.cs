using UserManager.Data.Model;
using UserManager.Models;

namespace UserManager.Service
{
    public interface IUserService
    {
        public Task CreateUserAsync(string username, string password, int roleId);
        public Task<List<User>> GetAllUsersAsync();
        public Task UpdateUserAsync(User newData);
        public Task DeleteUserAsync(int userId);
        public Task<List<UserViewModel>> SearchAsync(string query);
        public Task<User> GetUserByIdAsync(int userId);
        public Task<User> GetUserByUsernameAsync(string username);
        
    }
}
