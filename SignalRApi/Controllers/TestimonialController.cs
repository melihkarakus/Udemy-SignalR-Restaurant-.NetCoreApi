using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDtos>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDtos createTestimonialDtos)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Name = createTestimonialDtos.Name,
                Comment = createTestimonialDtos.Comment,
                Title = createTestimonialDtos.Title,
                ImageUrl = createTestimonialDtos.ImageUrl,
                Status = createTestimonialDtos.Status,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok("İşlem başarılı şekilde silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDtos updateTestimonialDtos)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = updateTestimonialDtos.TestimonialID,
                Name = updateTestimonialDtos.Name,
                Title = updateTestimonialDtos.Title,
                Comment = updateTestimonialDtos.Comment,
                ImageUrl = updateTestimonialDtos.ImageUrl,
                Status = updateTestimonialDtos.Status,
            });
            return Ok("İşlem başarılı şekilde güncellenmiştir.");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }
    }
}
