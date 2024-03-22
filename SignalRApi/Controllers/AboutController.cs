using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _mapper.Map<List<ResultAboutDtos>>(_aboutService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDtos createAboutDtos)
        {
            _aboutService.TAdd(new About()
            {
                Title = createAboutDtos.Title,
                Description = createAboutDtos.Description,
                ImageUrl = createAboutDtos.ImageUrl,
            });
            return Ok("Hakkımda kısmı başarılı şekilde eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımda kısmı başarılı şekilde silinmiştir.");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDtos updateAboutDtos)
        {
            _aboutService.TUpdate(new About()
            {
                AboutID = updateAboutDtos.AboutID,
                Title = updateAboutDtos.Title,
                Description = updateAboutDtos.Description,
                ImageUrl = updateAboutDtos.ImageUrl,
            });
            return Ok("Hakkımda kısmı başarılı şekilde güncellendi.");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
