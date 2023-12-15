﻿using BasicWebApi.Domain;
using BasicWebApi.Domain.DTOs;
using BasicWebApi.Domain.Models;
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
        private readonly ApplicationDbContext _context;

        public ContactController(IContactService contactService, ApplicationDbContext context)
        {
            _contactService = contactService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactApiResponse>>> GetAllContacts()
        {
            var result = await _contactService.GetAllContacts();
            List<ContactApiResponse> contacts = new List<ContactApiResponse>();
            foreach(var contact in result)
            {
                contacts.Add(new ContactApiResponse
                {
                    ContactId = contact.ContactId,
                    ContactName = contact.ContactName,
                    CompanyId = contact.ComapnyId,
                    CompanyName = contact.Company.CompanyName,
                    CountryId = contact.CountryId,
                    CountryName = contact.Country.CountryName
                });
            }
            return Ok(contacts);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDTO contact)
        {
            if (!ModelState.IsValid) return BadRequest(contact);

            var Company = _context.Set<Company>().FirstOrDefault(c => c.CompanyId == contact.CompanyId)!;
            var Country = _context.Set<Country>().FirstOrDefault(c => c.CountryId == contact.CountryId)!;

            var Contact = new Contact
            {
                ContactName = contact.ContactName,
                ComapnyId = contact.CompanyId,
                Company = Company,
                CountryId = contact.CountryId,
                Country = Country
            };

            var result = await _contactService.CreateContact(Contact);
            return Ok(result);

        }

        [HttpPut]
        public async Task<ActionResult<ContactApiResponse>> UpdateContact(int id, ContactDTO contact)
        {
            if (!ModelState.IsValid) { return BadRequest(contact); }

            var update = await _context.Set<Contact>().FirstOrDefaultAsync(x => x.ContactId == id);

            update.ComapnyId = contact.CompanyId;
            update.Company = _context.Set<Company>().FirstOrDefault(x => x.CompanyId == contact.CompanyId);
            update.ContactName = contact.ContactName;
            update.CountryId = contact.CountryId;
            update.Country = _context.Set<Country>().FirstOrDefault(x => x.CountryId == contact.CountryId);


            await _contactService.UpdateCompany(update);

            var updatedContact = new ContactApiResponse
            {
                ContactId = update.ContactId,
                ContactName = update.ContactName,
                CountryId = update.CountryId,
                CompanyId = update.ComapnyId,
                CompanyName = update.Company.CompanyName,
                CountryName = update.Country.CountryName
            };

            return Ok(updatedContact);
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            _contactService.DeleteContact(id);
            return Ok("Deleted contact with id: " + id + " !");
        }

        [HttpGet("/filter")]
        public async Task<ActionResult<ICollection<ContactApiResponse>>> FilterContact([FromQuery] int companyId, [FromQuery] int countryId)
        {
            var result = await _contactService.FilterContact(companyId, countryId);
            List<ContactApiResponse> contacts = new List<ContactApiResponse>();
            foreach(var contact in result)
            {
                var c = new ContactApiResponse
                {
                    ContactId = contact.ContactId,
                    ContactName = contact.ContactName,
                    CountryId = contact.CountryId,
                    CompanyId = contact.ComapnyId,
                    CompanyName = contact.Company.CompanyName,
                    CountryName = contact.Country.CountryName
                };
                contacts.Add(c);
            }
            return Ok(contacts);
        }

        [HttpGet("/get")]
        public async Task<ActionResult<ContactApiResponse>> GetContact(int id)
        {
            var result = await _contactService.GetContactWithCompanyAndCountry(id);
            var contact = new ContactApiResponse
            {
                ContactId = result.ContactId,
                ContactName = result.ContactName,
                CountryId = result.CountryId,
                CompanyId = result.ComapnyId,
                CompanyName = result.Company.CompanyName,
                CountryName = result.Country.CountryName
            };

            return Ok(contact);
        }
    }
}
