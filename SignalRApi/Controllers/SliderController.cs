using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDtos>>(_sliderService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDtos createSliderDtos)
        {
            _sliderService.TAdd(new Slider()
            {
                Description1 = createSliderDtos.Description1,
                Title1 = createSliderDtos.Title1,
                Description2 = createSliderDtos.Description2,
                Title2 = createSliderDtos.Title2,
                Description3 = createSliderDtos.Description3,
                Title3 = createSliderDtos.Title3,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var values = _sliderService.TGetByID(id);
            _sliderService.TDelete(values);
            return Ok("İşlem başarılı şekilde silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDtos updateSliderDtos)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderID = updateSliderDtos.SliderID,
                Description1 = updateSliderDtos.Description1,
                Title1 = updateSliderDtos.Title1,
                Description2 = updateSliderDtos.Description2,
                Title2 = updateSliderDtos.Title2,
                Description3 = updateSliderDtos.Description3,
                Title3 = updateSliderDtos.Title3,
            });
            return Ok("İşlem başarılı şekilde güncellenmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var values = _sliderService.TGetByID(id);
            return Ok(values);
        }
    }
}
