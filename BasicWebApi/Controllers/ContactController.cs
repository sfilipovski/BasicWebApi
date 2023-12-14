using BasicWebApi.Domain;
using BasicWebApi.Domain.DTOs;
using BasicWebApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var result = await _contactService.GetAllContacts();
            return Ok(result);
        }
        /*[HttpPost]
        public async Task<ActionResult> CreateContact(ContactDTO contact)
        {

        }*/
    }
}
