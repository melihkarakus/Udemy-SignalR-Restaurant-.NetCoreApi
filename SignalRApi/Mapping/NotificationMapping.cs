using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, ResultNotificationDtos>().ReverseMap();
            CreateMap<Notification, CreateNotificationDtos>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDtos>().ReverseMap();
        }
    }
}
