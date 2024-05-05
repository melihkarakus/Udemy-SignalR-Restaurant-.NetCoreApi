using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDtos>>(_bookingService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDtos createBookingDtos)
        {
            _bookingService.TAdd(new Booking()
            {
                Date = createBookingDtos.Date,
                Mail = createBookingDtos.Mail,
                Name = createBookingDtos.Name,
                PersonelCount = createBookingDtos.PersonelCount,
                Phone = createBookingDtos.Phone,
                Description = createBookingDtos.Description,    
            });
            return Ok("Rezervasyon başarıyla eklendi.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok("Rezervasyon başarıyla silinmiştir.");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDtos updateBookingDtos)
        {
            _bookingService.TUpdate(new Booking()
            {
                BookingID = updateBookingDtos.BookingID,
                Mail = updateBookingDtos.Mail,
                Date = updateBookingDtos.Date,
                Name = updateBookingDtos.Name,
                PersonelCount = updateBookingDtos.PersonelCount,
                Phone = updateBookingDtos.Phone,
            });
            return Ok("Rezervasyon başarıyla güncellenmiştir.");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.BookingStatusApproved(id);
            return Ok("Rezervasyon Onaylandı.");
        }
        [HttpGet("BookingStatusCancel/{id}")]
        public IActionResult BookingStatusCancel(int id)
        {
            _bookingService.BookingStatusCancel(id);
            return Ok("Rezervasyon İptal Edildi.");
        }
    }
}
