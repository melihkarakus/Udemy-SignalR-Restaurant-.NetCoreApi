using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _mapper.Map<List<ResultMessageDtos>>(_messageService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDtos createMessageDtos)
        {
            _messageService.TAdd(new Message()
            {
                Mail = createMessageDtos.Mail,
                Subject = createMessageDtos.Subject,
                MessageContent = createMessageDtos.MessageContent,
                MessageSendDate = createMessageDtos.MessageSendDate,
                NameSurname = createMessageDtos.NameSurname,
                PhoneNumber = createMessageDtos.PhoneNumber,
                Status = createMessageDtos.Status,
            });
            return Ok("Mesaj Kaydedildi");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            _messageService.TDelete(values);
            return Ok("Mesaj Silindi");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDtos updateMessageDtos)
        {
            _messageService.TUpdate(new Message()
            {
                MessageID = updateMessageDtos.MessageID,
                Mail = updateMessageDtos.Mail,
                MessageContent = updateMessageDtos.MessageContent,
                MessageSendDate = updateMessageDtos.MessageSendDate,
                PhoneNumber = updateMessageDtos.PhoneNumber,
                Subject = updateMessageDtos.Subject,
                NameSurname = updateMessageDtos.NameSurname,
                Status = updateMessageDtos.Status,
            });
            return Ok("Mesaj Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            return Ok(values);
        }
    }
}
