using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDtos>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDtos createSocialMediaDtos)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title = createSocialMediaDtos.Title,
                Url = createSocialMediaDtos.Url,
                Icon = createSocialMediaDtos.Icon,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(values);
            return Ok("İşlem başarılı şekilde silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDtos updateSocialMediaDtos)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDtos.SocialMediaID,
                Title = updateSocialMediaDtos.Title,
                Icon = updateSocialMediaDtos.Icon,
                Url = updateSocialMediaDtos.Url,
            });
            return Ok("İşlem başarılı şekilde güncellenmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            return Ok(values);
        }
    }
}
