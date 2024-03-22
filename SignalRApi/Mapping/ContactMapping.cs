using AutoMapper;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDtos>().ReverseMap();
            CreateMap<Contact, CreateContactDtos>().ReverseMap();
            CreateMap<Contact, UpdateContactDtos>().ReverseMap();
            CreateMap<Contact, GetContactDtos>().ReverseMap();
        }
    }
}
