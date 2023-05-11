using Mail.WebAPI.DTOs;

namespace Mail.WebAPI.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<UserDto> LoginAsync(UserDto loginUser);
        public Task<bool> RegistrationAsync(UserDto registrationUser);

    }
}