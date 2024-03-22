using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDtos>>(_contactService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDtos createContactDtos)
        {
            _contactService.TAdd(new Contact()
            {
                FooterDescription = createContactDtos.FooterDescription,
                Location = createContactDtos.Location,
                Mail = createContactDtos.Mail,
                Phone = createContactDtos.Phone,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return Ok("İşlem başarılı şekilde silinmiştir.");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDtos updateContactDtos)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDtos.ContactID,
                FooterDescription = updateContactDtos.FooterDescription,
                Location = updateContactDtos.Location,
                Mail = updateContactDtos.Mail,
                Phone = updateContactDtos.Phone,
            });
            return Ok("İşlem başarılı şekilde eklenmiştir.");
        }
    }
}
