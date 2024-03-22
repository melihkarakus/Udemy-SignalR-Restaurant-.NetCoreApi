using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, ResultBookingDtos>().ReverseMap();
            CreateMap<Booking, CreateBookingDtos>().ReverseMap();
            CreateMap<Booking, UpdateBookingDtos>().ReverseMap();
            CreateMap<Booking, GetBookingDtos>().ReverseMap();
        }
    }
}
