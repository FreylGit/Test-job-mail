using Mail.WebAPI.DTOs;
using Mail.WebAPI.Services.Interfaces;

namespace Mail.WebAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;
        public AccountService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<UserDto> LoginAsync(UserDto loginUser)
        {
            if (loginUser == null)
            {
                throw new ArgumentNullException(nameof(loginUser));
            }
            var user = await _userService.GetUserByNameAndEmail(loginUser);
            if (user == null)
            {
                throw new ArgumentNullException("Пользователь не найден", nameof(user));
            }
            return user;
        }

        public async Task<bool> RegistrationAsync(UserDto registrationUser)
        {
            if (registrationUser == null)
            {
                throw new ArgumentNullException(nameof(registrationUser));
            }
            await _userService.CreateUserAsync(registrationUser);
            return true;
        }
    }
}
