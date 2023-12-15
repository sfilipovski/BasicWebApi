using AutoMapper;
using BasicWebApi.Domain.Models;
using BasicWebApi.Domain.Request;
using BasicWebApi.Domain.Response;
using BasicWebApi.Repository;
using BasicWebApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ContactController(IContactService contactService, IMapper mapper, ApplicationDbContext context)
        {
            _contactService = contactService;
            this._mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactResponse>>> GetAllContacts()
        {
            var result = await _contactService.GetAllContacts();
            var contacts = _mapper.Map<List<ContactResponse>>(result);

            return Ok(contacts);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var contact = _mapper.Map<Contact>(request);

            var company = _context.Set<Company>().FirstOrDefault(c => c.CompanyId == request.CompanyId)!;
            var country = _context.Set<Country>().FirstOrDefault(c => c.CountryId == request.CountryId)!;

            contact.Company = company;
            contact.Country = country;

            var result = await _contactService.CreateContact(contact);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult<ContactResponse>> UpdateContact(UpdateContactRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }


            var contact = _mapper.Map<Contact>(request);

            var company = _context.Set<Company>().FirstOrDefault(c => c.CompanyId == request.CompanyId)!;
            var country = _context.Set<Country>().FirstOrDefault(c => c.CountryId == request.CountryId)!;

            contact.Company = company;
            contact.Country = country;

            var result = await _contactService.UpdateCompany(contact);
            var response = _mapper.Map<ContactResponse>(result);

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
            return Ok("Deleted contact with id: " + id + " !");
        }

        [HttpGet("/filter")]
        public async Task<ActionResult<ICollection<ContactResponse>>> FilterContact([FromQuery] int companyId, [FromQuery] int countryId)
        {
            var result = await _contactService.FilterContact(companyId, countryId);
            var response = _mapper.Map<List<ContactResponse>>(result);

            return Ok(response);
        }

        [HttpGet("/get")]
        public async Task<ActionResult<ContactResponse>> GetContact(int id)
        {
            var result = await _contactService.GetContactWithCompanyAndCountry(id);
            var response = _mapper.Map<ContactResponse>(result);

            return Ok(response);
        }
    }
}
