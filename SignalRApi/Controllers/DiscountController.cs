using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDtos>>(_discountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDtos createDiscountDtos)
        {
            _discountService.TAdd(new Discount()
            {
                Title = createDiscountDtos.Title,
                Description = createDiscountDtos.Description,
                Amount = createDiscountDtos.Amount,
                ImageUrl = createDiscountDtos.ImageUrl,
                Status = false,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetByID(id);
            _discountService.TDelete(values);
            return Ok("İşlem başarılı şekilde silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDtos updateDiscountDtos)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = updateDiscountDtos.DiscountID,
                Title = updateDiscountDtos.Title,
                Description = updateDiscountDtos.Description,
                Amount = updateDiscountDtos.Amount,
                ImageUrl = updateDiscountDtos.ImageUrl,
                Status = false,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Durum Güncellendi");
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Durum Güncellendi");
        }
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            return Ok(_discountService.GetListByStatusTrue());
        }
    }
}
