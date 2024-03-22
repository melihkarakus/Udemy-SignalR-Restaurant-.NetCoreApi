using AutoMapper;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<Discount, ResultDiscountDtos>().ReverseMap();
            CreateMap<Discount, CreateDiscountDtos>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDtos>().ReverseMap();
            CreateMap<Discount, GetDiscountDtos>().ReverseMap();
        }
    }
}
