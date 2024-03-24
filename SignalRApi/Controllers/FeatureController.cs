using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDtos>>(_featureService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDtos createFeatureDtos)
        {
            _featureService.TAdd(new Feature()
            {
                Description1 = createFeatureDtos.Description1,
                Title1 = createFeatureDtos.Title1,
                Description2 = createFeatureDtos.Description2,
                Title2 = createFeatureDtos.Title2,
                Description3 = createFeatureDtos.Description3,
                Title3 = createFeatureDtos.Title3,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            _featureService.TDelete(values);
            return Ok("İşlem başarılı şekilde silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDtos updateFeatureDtos)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = updateFeatureDtos.FeatureID,
                Description1 = updateFeatureDtos.Description1,
                Title1 = updateFeatureDtos.Title1,
                Description2 = updateFeatureDtos.Description2,
                Title2 = updateFeatureDtos.Title2,
                Description3 = updateFeatureDtos.Description3,
                Title3 = updateFeatureDtos.Title3,
            });
            return Ok("İşlem başarılı şekilde güncellenmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var values = _featureService.TGetByID(id);
            return Ok(values);
        }
    }
}
