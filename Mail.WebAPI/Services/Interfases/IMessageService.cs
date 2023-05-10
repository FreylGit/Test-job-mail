using Mail.WebAPI.DTOs;

namespace Mail.WebAPI.Services.Interfases
{
    public interface IMessageService
    {
        public Task<MessageDto> GetMessageByIdAsync(int id);
        public Task<ICollection<MessageDto>> GetMessagesAsync();
        public Task<ICollection<MessageDto>> GetMessagesByUserIdAsync(int userId);
        public Task DeleteMessageAsync(int id);
        public Task UpdateMessageAsync(MessageDto updateMessage);
        public Task CreateMessageAsync(MessageDto createMessage);
    }
}
