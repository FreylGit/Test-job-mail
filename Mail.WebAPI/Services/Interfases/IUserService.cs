using Mail.WebAPI.DTOs;

namespace Mail.WebAPI.Services.Interfases
{
    public interface IUserService
    {
        public Task CreateUserAsync(UserDto createUser);
        public Task<IEnumerable<UserDto>> GetUsersAsync();
        public Task<UserDto> GetUserByIdAsync(int id);
        public Task UpdateUserAsync(UserDto updateUser);
        public Task DeleteUserAsync(int id);
        public Task<UserDto> GetUserByNameAndEmail(UserDto user);
    }
}
