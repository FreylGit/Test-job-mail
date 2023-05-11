using Mail.WebAPI.DTOs;
using Mail.WebAPI.Models.Post;

namespace Mail.WebAPI.Services.Interfaces
{
    public interface IMessageService
    {
        public Task<MessageView> GetMessageByIdAsync(int id);
        public Task<ICollection<MessageDto>> GetMessagesAsync();
        public Task<ICollection<MessageDto>> GetMessagesByUserIdAsync(int userId);
        public Task DeleteMessageAsync(int id);
        public Task UpdateMessageAsync(MessageDto updateMessage);
        public Task CreateMessageAsync(MessageView createMessage);
    }
}
