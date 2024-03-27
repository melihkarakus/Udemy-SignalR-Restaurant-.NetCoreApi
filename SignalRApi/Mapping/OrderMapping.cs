using AutoMapper;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class OrderMapping : Profile
	{
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderDtos>().ReverseMap();
            CreateMap<Order, CreateOrderDtos>().ReverseMap();
            CreateMap<Order, UpdateOrderDtos>().ReverseMap();
            CreateMap<Order, GetOrderDtos>().ReverseMap();
        }
    }
}
