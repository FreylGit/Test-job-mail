using Mail.WebAPI.DTOs;

namespace Mail.WebAPI.Services.Interfases
{
    public interface IAccountService
    {
        public Task<UserDto> LoginAsync(UserDto loginUser);
        public Task<bool> RegistrationAsync(UserDto registrationUser);

    }
}