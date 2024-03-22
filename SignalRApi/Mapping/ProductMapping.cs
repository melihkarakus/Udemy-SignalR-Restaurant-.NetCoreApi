using AutoMapper;
using SignalR.DtoLayer.ProductDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductDtos>().ReverseMap();
            CreateMap<Product, CreateProductDtos>().ReverseMap();
            CreateMap<Product, UpdateProductDtos>().ReverseMap();
            CreateMap<Product, GetProductDtos>().ReverseMap();
            CreateMap<Product, ResultProductWithCategory>().ReverseMap();
        }
    }
}
