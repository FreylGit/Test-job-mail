using Mail.WebAPI.Data.Interfaces;
using Mail.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mail.WebAPI.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateMessageAsync(Message createMessage)
        {
            await _context.Messages.AddAsync(createMessage);
            return await SaveAsync();
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var messageDeleted = await _context.Messages.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (messageDeleted == null)
            {
                return false;
            }
            _context.Messages.Remove(messageDeleted);
            return await SaveAsync();
        }

        public async Task<bool> ExistsMessageAsync(int id)
        {
            var messageCheck = await _context.Messages.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (messageCheck == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Message> GetMassageByIdAsync(int id)
        {
            var message = await _context.Messages.Where(m => m.Id == id).FirstOrDefaultAsync();
            return message;
        }

        public async Task<ICollection<Message>> GetMessagesAsync()
        {
            var messages = await _context.Messages.ToListAsync();
            return messages;
        }

        public async Task<ICollection<Message>> GetMessagesByUserIdAsync(int userId)
        {
            var messages = await _context.Messages.Where(m => m.AddresseeId == userId).ToListAsync();
            return messages;
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0 ? true : false;
        }

        public async Task<bool> UpdateMessageAsync(Message message)
        {
            var messageData = _context.Messages.Where(m => m.Id == message.Id).FirstOrDefault();
            if (messageData.AddresseeId != message.AddresseeId || messageData.SenderId != message.SenderId)
            {
                return false;
            }
            _context.Entry(messageData).State = EntityState.Detached; // Отключение отслеживания
            _context.Messages.Update(message);
            return await SaveAsync();
        }
    }
}
