using AutoMapper;
using BasicWebApi.Domain.Models;
using BasicWebApi.Domain.Request;
using BasicWebApi.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Profile;

public static class MapperProfile
{
    public static IMapper Initialize()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Company, CompanyResponse>();
            cfg.CreateMap<Contact, ContactResponse>();
            cfg.CreateMap<CreateCompanyRequest, Company>();
            cfg.CreateMap<UpdateCompanyRequest, Company>();
            cfg.CreateMap<Country, CountryResponse>();
            cfg.CreateMap<CreateCountryRequest, Country>();
            cfg.CreateMap<UpdateCountryRequest, Country>();

        });

        return config.CreateMapper();
    }
}
