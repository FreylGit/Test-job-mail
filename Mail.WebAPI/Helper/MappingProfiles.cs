using AutoMapper;
using Mail.WebAPI.DTOs;
using Mail.WebAPI.Models;

namespace Mail.WebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();

        }
    }
}
