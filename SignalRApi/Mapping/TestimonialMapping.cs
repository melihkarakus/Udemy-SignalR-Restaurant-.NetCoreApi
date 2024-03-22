using AutoMapper;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, ResultTestimonialDtos>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDtos>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDtos>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDtos>().ReverseMap();
        }
    }
}
