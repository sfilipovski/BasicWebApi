using BasicWebApi.Domain.DTOs;
using BasicWebApi.Domain;
using BasicWebApi.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await countryService.GetAllCountries();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<CountryDTO>> CreateCountry(CountryDTO country)
        {
            if (!ModelState.IsValid) return BadRequest(country);

            var Country = new Country
            {
                CountryName = country.CountryName
            };

            var result = await countryService.CreateCountry(Country);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Country>> UpdateCountry(int id, CountryDTO country)
        {
            if (!ModelState.IsValid) return BadRequest(country);

            var Country = new Country
            {
                CountryId = id,
                CountryName = country.CountryName
            };

            var result = await countryService.UpdateCountry(Country);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            countryService.DeleteCountry(id);
            return Ok("Deleted Country with id: " + id + " !");
        }
    }
}
