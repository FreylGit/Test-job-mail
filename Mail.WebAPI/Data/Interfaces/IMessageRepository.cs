using Mail.WebAPI.Models;

namespace Mail.WebAPI.Data.Interfaces
{
    public interface IMessageRepository
    {
        public Task<bool> CreateMessageAsync(Message createMessage);
        public Task<ICollection<Message>> GetMessagesAsync();
        public Task<Message> GetMassageByIdAsync(int id);
        public Task<ICollection<Message>> GetMessagesByUserIdAsync(int userId);
        public Task<bool> DeleteMessageAsync(int id);
        public Task<bool> UpdateMessageAsync(Message message);
        public Task<bool> ExistsMessageAsync(int id);
        public Task<bool> SaveAsync();
    }
}
