using AutoMapper;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<Message, ResultMessageDtos>().ReverseMap();
            CreateMap<Message, CreateMessageDtos>().ReverseMap();
            CreateMap<Message, UpdateMessageDtos>().ReverseMap();
            CreateMap<Message, GetByIDMessageDtos>().ReverseMap();
        }
    }
}
