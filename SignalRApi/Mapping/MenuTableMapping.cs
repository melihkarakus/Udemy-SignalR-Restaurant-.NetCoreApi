using AutoMapper;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class MenuTableMapping : Profile
    {
        public MenuTableMapping()
        {
            CreateMap<MenuTable, CreateMenuTableDtos>().ReverseMap();
            CreateMap<MenuTable, UpdateMenuTableDtos>().ReverseMap();
            CreateMap<MenuTable, ResultMenuTableDtos>().ReverseMap();
            CreateMap<MenuTable, GetMenuTableDtos>().ReverseMap();
        }
    }
}
