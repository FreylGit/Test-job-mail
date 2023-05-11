using AutoMapper;
using Mail.WebAPI.Data.Interfases;
using Mail.WebAPI.DTOs;
using Mail.WebAPI.Models;
using Mail.WebAPI.Models.Post;
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


        public async Task CreateMessageAsync(MessageView createMessage)
        {
            if (createMessage == null)
            {
                throw new ArgumentNullException(nameof(createMessage));
            }
            if(createMessage.EmailAddressee.ToLower() == createMessage.EmailSender.ToLower())
            {
                throw new ArgumentException("Одинаковые email", nameof(createMessage));
            }
            var addressee = await _userRepository.GetUserByEmailAsync(createMessage.EmailAddressee);
            if (addressee == null)
            {
                throw new ArgumentNullException("Адресат с таким email не найден", nameof(createMessage));
            }
            var sender = await _userRepository.GetUserByEmailAsync(createMessage.EmailSender);
            if (sender == null)
            {
                throw new ArgumentNullException("Отправитель с таким email не найден", nameof(createMessage));
            }
            var message = new Message()
            {
                Title = createMessage.Title,
                Content = createMessage.Content,
                DateTime = DateTime.Now,
                AddresseeId = addressee.Id,
                SenderId = sender.Id,

            };
            if (!await _messageRepository.CreateMessageAsync(message))
            {
                throw new ArgumentException("Не удалось сохранить message", nameof(createMessage));
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

        public async Task<MessageView> GetMessageByIdAsync(int id)
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

            var addressee = await _userRepository.GetUserByIdAsync(message.AddresseeId);
            var sender = await _userRepository.GetUserByIdAsync(message.SenderId);
            var messageView = new MessageView()
            {
                Title = message.Title,
                Content = message.Content,
                EmailAddressee = addressee.Email,
                EmailSender = sender.Email
            };
            
            return messageView;

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
