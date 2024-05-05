using AutoMapper;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDtos>().ReverseMap();
            CreateMap<Slider, CreateSliderDtos>().ReverseMap();
            CreateMap<Slider, UpdateSliderDtos>().ReverseMap();
            CreateMap<Slider, GetSliderDtos>().ReverseMap();
        }
    }
}
