using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            //Entity sınıfı ile dtos sınıfını eşleştirmek için yapıyoruz.
            CreateMap<About, ResultAboutDtos>().ReverseMap();
            CreateMap<About, CreateAboutDtos>().ReverseMap();
            CreateMap<About, UpdateAboutDtos>().ReverseMap();
            CreateMap<About, GetAboutDtos>().ReverseMap();
        }
    }
}
