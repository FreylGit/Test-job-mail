using Mail.WebAPI.Data.Interfases;
using Mail.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mail.WebAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            var userCheck = await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
            if (userCheck != null)
            {
                return false;
            }
            await _context.Users.AddAsync(user);
            return await SaveAsync();
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            var messages = _context.Messages.Where(m => m.AddresseeId == id);
            _context.Messages.RemoveRange(messages);
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            _context.Users.Remove(user);
            return await SaveAsync();
        }

        public async Task<bool> ExistsUserAsync(int id)
        {
            var userCheck = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (userCheck != null)
            {
                return true;
            }
            return false;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> GetUserByNameAndEmailAsync(string name, string email)
        {
            var user = await _context.Users.Where(u=>u.Name==name && u.Email==email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> UpdateUserAsync(User newUser)
        {
            _context.Users.Update(newUser);
            return await SaveAsync();
        }
    }
}
