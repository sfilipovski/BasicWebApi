using BasicWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Service.Interface;

public interface ICountryService
{
    Task<ICollection<Country>> GetAllCountries();
    Task<int> CreateCountry(Country entity);
    Task<Country> UpdateCountry(Country entity);
    void DeleteCountry(int id);
}
