using AutoMapper;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDtos>().ReverseMap();
            CreateMap<Category, CreateCategoryDtos>().ReverseMap();
            CreateMap<Category, UpdateCategoryDtos>().ReverseMap();
            CreateMap<Category, GetCategoryDtos>().ReverseMap();
        }
    }
}
