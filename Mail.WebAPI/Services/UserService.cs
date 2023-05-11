using AutoMapper;
using Mail.WebAPI.Data.Interfaces;
using Mail.WebAPI.DTOs;
using Mail.WebAPI.Models;
using Mail.WebAPI.Services.Interfaces;

namespace Mail.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task CreateUserAsync(UserDto createUser)
        {
            if (createUser == null)
            {
                throw new ArgumentNullException(nameof(createUser));
            }
            var userMap = _mapper.Map<User>(createUser);
            if (userMap == null)
            {
                throw new ArgumentException("Failed to cast model", nameof(userMap));
            }
            if (!await _userRepository.CreateUserAsync(userMap))
            {
                throw new ArgumentException("Failed to save model", nameof(userMap));
            }

        }

        public async Task DeleteUserAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect id");
            }
            if (!await _userRepository.ExistsUserAsync(id))
            {
                throw new ArgumentNullException("User with this id was not found");
            }
            if (!await _userRepository.DeleteUserByIdAsync(id))
            {
                throw new ArgumentException("Failed to delete user");
            }
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect id");
            }
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var userMap = _mapper.Map<UserDto>(user);
            if (userMap == null)
            {
                throw new ArgumentException("Failed to cast model", nameof(userMap));
            }
            return userMap;
        }

        public async Task<UserDto> GetUserByNameAndEmail(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Email == null || user.Name == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userData = await _userRepository.GetUserByNameAndEmailAsync(user.Name, user.Email);
            if (userData == null)
            {
                throw new ArgumentNullException("Пользователь не найден",nameof(user));
            }

            var userMap = _mapper.Map<UserDto>(userData);
            if (userMap == null)
            {
                throw new ArgumentException("Failed to cast model", nameof(userMap));
            }
            return userMap;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            var usersMap = _mapper.Map<ICollection<UserDto>>(users);
            if (usersMap == null)
            {
                throw new ArgumentException("Failed to cast model", nameof(users));
            }
            return usersMap;
        }

        public async Task UpdateUserAsync(UserDto updateUser)
        {
            if (updateUser.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect id");
            }
            if (updateUser == null)
            {
                throw new ArgumentNullException(nameof(updateUser));
            }
            var userMap = _mapper.Map<User>(updateUser);

            if (userMap == null)
            {
                throw new ArgumentException("Failed to cast model", nameof(userMap));
            }
            if (!await _userRepository.UpdateUserAsync(userMap))
            {
                throw new ArgumentException("Failed to update data", nameof(userMap));
            }
        }
    }
}
