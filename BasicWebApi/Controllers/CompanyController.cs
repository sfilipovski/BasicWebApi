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
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var result =  await companyService.GetAllCompanies();
            return Ok(result);
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
