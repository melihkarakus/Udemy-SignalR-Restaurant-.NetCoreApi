using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _mapper.Map<List<ResultNotificationDtos>>(_notificationService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDtos createNotificationDtos)
        {
            _notificationService.TAdd(new Notification()
            {
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Description = createNotificationDtos.Description,
                Icon = createNotificationDtos.Icon,
                Status = false,
                Type = createNotificationDtos.Type,
            });
            return Ok("Yeni Bildirim Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var values = _notificationService.TGetByID(id);
            _notificationService.TDelete(values);
            return Ok("Bildirim Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDtos updateNotificationDtos)
        {
            _notificationService.TUpdate(new Notification()
            {
                NotificationID = updateNotificationDtos.NotificationID,
                Date = updateNotificationDtos.Date,
                Description = updateNotificationDtos.Description,
                Icon = updateNotificationDtos.Icon,
                Status = updateNotificationDtos.Status,
                Type = updateNotificationDtos.Type,
            });
            return Ok("Bildirim Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var values = _notificationService.TGetByID(id);
            return Ok(values);
        }


        [HttpGet("TNotificationCountByStatusFalse")]
        public IActionResult TNotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("TGetAllNotificationsByFalse")]
        public IActionResult TGetAllNotificationsByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationsByFalse());
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı.");
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı.");
        }
    }
}
