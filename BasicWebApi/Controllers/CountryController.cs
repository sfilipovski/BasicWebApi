using BasicWebApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BasicWebApi.Domain.Models;
using BasicWebApi.Domain.Response;
using AutoMapper;
using BasicWebApi.Domain.Request;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            this.countryService = countryService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCountries()
        {
            var result = await countryService.GetAllCountries();
            var countries = _mapper.Map<List<CountryResponse>>(result);

            return Ok(countries);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCountry(CreateCountryRequest request)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(request.CountryName)) return BadRequest(ModelState);

            var country = _mapper.Map<Country>(request);
            var result = await countryService.CreateCountry(country);

            if(result==1) return Ok("Added country: "+request.CountryName);

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult<CountryResponse>> UpdateCountry(UpdateCountryRequest request)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(request.CountryName)) return BadRequest(ModelState);

            var country = _mapper.Map<Country>(request);

            var result = await countryService.UpdateCountry(country);
            if (result == null) return BadRequest(result);

            var response = _mapper.Map<CountryResponse>(result);

            return Ok(response);
        }

        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            countryService.DeleteCountry(id);
            return Ok("Deleted Country with id: " + id + " !");
        }
    }
}
