using AutoMapper;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDtos>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDtos>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDtos>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaDtos>().ReverseMap();
        }
    }
}
