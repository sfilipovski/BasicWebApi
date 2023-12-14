using BasicWebApi.Domain;
using BasicWebApi.Domain.DTOs;
using BasicWebApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyResponse>>> GetAllCompanies()
        {
            var result =  await companyService.GetAllCompanies();
            List<CompanyResponse> companies = new List<CompanyResponse>();
            foreach (var company in result)
            {
                var c = new CompanyResponse
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName
                };
                var contacts = company.Contacts?.Select(x => new ContactResponse { ContactId = x.ContactId, ContactName = x.ContactName }).ToList();
                if (contacts != null)
                {
                    c.Contacts = contacts;
                    companies.Add(c);
                }
            }
            return Ok(companies);
        }
        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> CreateCompany(CompanyDTO company)
        {
            if (!ModelState.IsValid) return BadRequest(company);

            var Company = new Company
            {
                CompanyName = company.CompanyName
            };

            var result = await companyService.CreateCompany(Company);
            return Ok(result); 
        }

        [HttpPut]
        public async Task<ActionResult<Company>> UpdateCompany(int id, CompanyDTO company)
        {
            if (!ModelState.IsValid) return BadRequest(company);

            var Company = new Company
            {
                CompanyId = id,
                CompanyName = company.CompanyName
            };

            var result = await companyService.UpdateCompany(Company);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            companyService.DeleteCompany(id);
            return Ok("Deleted Company with id :" + id + " !");
        }
    }
}
