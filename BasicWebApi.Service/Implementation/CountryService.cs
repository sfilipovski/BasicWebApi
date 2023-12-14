using BasicWebApi.Domain;
using BasicWebApi.Repository.Interface;
using BasicWebApi.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Service.Implementation;

public class CountryService : ICountryService
{
    private readonly IRepository<Country> _countryRepository;

    public CountryService(IRepository<Country> countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<int> CreateCountry(Country entity)
    {
        return await _countryRepository.Create(entity);
    }

    public void DeleteCountry(int id)
    {
         _countryRepository.Delete(id); 
    }

    public async Task<ICollection<Country>> GetAllCountries()
    {
        return await _countryRepository.Get();
    }

    public async Task<Country> UpdateCountry(Country entity)
    {
        return await _countryRepository.Update(entity);             
    }
}
