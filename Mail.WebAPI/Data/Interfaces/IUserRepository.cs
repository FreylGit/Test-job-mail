using Mail.WebAPI.Models;

namespace Mail.WebAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserByEmailAsync(string email);
        public Task<bool> CreateUserAsync(User user);
        public Task<bool> UpdateUserAsync(User newUser);
        public Task<bool> DeleteUserByIdAsync(int id);
        public Task<bool> SaveAsync();
        public Task<bool> ExistsUserAsync(int id);
        public Task<User> GetUserByNameAndEmailAsync(string name, string email);

    }
}
