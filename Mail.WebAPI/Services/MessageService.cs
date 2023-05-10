using AutoMapper;
using Mail.WebAPI.Data.Interfases;
using Mail.WebAPI.DTOs;
using Mail.WebAPI.Models;
using Mail.WebAPI.Services.Interfases;

namespace Mail.WebAPI.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        public MessageService(IMapper mapper, IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _userRepository = userRepository;

        }
        public async Task CreateMessageAsync(MessageDto createMessage)
        {
            if (createMessage == null)
            {
                throw new ArgumentNullException(nameof(createMessage));
            }
            if (createMessage.AddresseeId == createMessage.SenderId)
            {
                throw new ArgumentException("addresse id and sender id are the same");
            }
            if (!await _userRepository.ExistsUserAsync(createMessage.AddresseeId))
            {
                throw new ArgumentException("addresse with this id does not exist");
            }
            if (!await _userRepository.ExistsUserAsync(createMessage.SenderId))
            {
                throw new ArgumentException("there is no sender with this id");
            }
            var messageMap = _mapper.Map<Message>(createMessage);
            if (messageMap == null)
            {
                throw new ArgumentException("Failed to cast model", nameof(messageMap));
            }
            if (!await _messageRepository.CreateMessageAsync(messageMap))
            {
                throw new ArgumentException("Failed to save", nameof(messageMap));
            }
        }

        public async Task DeleteMessageAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect id");  
            }
            if (!await _messageRepository.ExistsMessageAsync(id))
            {
                throw new ArgumentNullException("No message with this id");
            }
            if (!await _messageRepository.DeleteMessageAsync(id))
            {
                throw new ArgumentException("Failed to delete message");
            }
        }

        public async Task<MessageDto> GetMessageByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect id");
            }
            if (!await _messageRepository.ExistsMessageAsync(id))
            {
                throw new ArgumentException("There is no message with this id");
            }
            var message = await _messageRepository.GetMassageByIdAsync(id);
            var messageMap = _mapper.Map<MessageDto>(message);
            if (messageMap == null)
            {
                throw new ArgumentNullException(nameof(messageMap));
            }
            return messageMap;

        }

        public async Task<ICollection<MessageDto>> GetMessagesAsync()
        {
            var messages = await _messageRepository.GetMessagesAsync();
            var messagesMap = _mapper.Map<ICollection<MessageDto>>(messages);
            if (messagesMap == null && messages != null)
            {
                throw new ArgumentException("Failed to cast types", nameof(messagesMap));
            }
            return messagesMap;
        }

        public async Task<ICollection<MessageDto>> GetMessagesByUserIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException("Incorrect id");
            }
            if (!await _userRepository.ExistsUserAsync(userId))
            {
                throw new ArgumentNullException("User with this id was not found");
            }
            var messages = await _messageRepository.GetMessagesByUserIdAsync(userId);
            var messagesMap = _mapper.Map<ICollection<MessageDto>>(messages);
            if (messagesMap == null && messages != null)
            {
                throw new ArgumentException("Failed to cast types", nameof(messagesMap));
            }
            return messagesMap;
        }

        public async Task UpdateMessageAsync(MessageDto updateMessage)
        {
            if (updateMessage == null)
            {
                throw new ArgumentNullException(nameof(updateMessage));
            }
            if (updateMessage.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Некорректный id");
            }
            var messageMap = _mapper.Map<Message>(updateMessage);
            if (messageMap == null)
            {
                throw new ArgumentException("Не удалось привести типы");
            }
            if (!await _messageRepository.UpdateMessageAsync(messageMap))
            {
                throw new ArgumentException("Не удалось обновить message");
            }

        }
    }
}
