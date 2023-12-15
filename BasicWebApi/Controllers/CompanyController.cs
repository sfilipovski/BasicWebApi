﻿using AutoMapper;
using BasicWebApi.Domain.Models;
using BasicWebApi.Domain.Request;
using BasicWebApi.Domain.Response;
using BasicWebApi.Repository;
using BasicWebApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyResponse>>> GetAllCompanies()
        {
            var result =  await companyService.GetAllCompanies();

            var companies = _mapper.Map<List<CompanyResponse>>(result);
            companies.ForEach(x => x.Contacts = _mapper.Map<List<ContactResponse>>(x.Contacts));
            

            return Ok(companies);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var company = _mapper.Map<Company>(request);

            var result = await companyService.CreateCompany(company);
            return Ok(result); 
        }

        [HttpPut]
        public async Task<ActionResult<CompanyResponse>> UpdateCompany(UpdateCompanyRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var company = _mapper.Map<Company>(request);

            var result = await companyService.UpdateCompany(company);
            var response = _mapper.Map<CompanyResponse>(result);

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult DeleteCompany(int id)
        {
            companyService.DeleteCompany(id);
            return Ok("Deleted Company with id :" + id + " !");
        }
    }
}
