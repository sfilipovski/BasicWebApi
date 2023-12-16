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
            cfg.CreateMap<Company, CompanyResponse>()
            .ForMember(dest => dest.Contacts,
                opt => opt.MapFrom(src => src.Contacts.Select(x => new ContactNameResponse { ContactName = x.ContactName, ContactId = x.ContactId})));
            cfg.CreateMap<CreateCompanyRequest, Company>();
            cfg.CreateMap<UpdateCompanyRequest, Company>();

            cfg.CreateMap<Country, CountryResponse>()
            .ForMember(dest => dest.Contacts,
                opt => opt.MapFrom(src => src.Contacts.Select(x => new ContactNameResponse { ContactName = x.ContactName, ContactId = x.ContactId })));
            cfg.CreateMap<CreateCountryRequest, Country>();
            cfg.CreateMap<UpdateCountryRequest, Country>();

            cfg.CreateMap<Contact, ContactNameResponse>();
            cfg.CreateMap<Contact, ContactResponse>()
            .ForMember(dest => dest.CompanyName,
                opt => opt.MapFrom(src => src.Company.CompanyName))
            .ForMember(dest => dest.CountryName,
                opt => opt.MapFrom(src => src.Country.CountryName))
            .ForMember(dest => dest.CompanyId,
                opt => opt.MapFrom(src => src.ComapnyId));
            cfg.CreateMap<CreateContactRequest, Contact>()
            .ForMember(dest => dest.ComapnyId,
                opt => opt.MapFrom(src => src.CompanyId));
            cfg.CreateMap<UpdateContactRequest, Contact>()
            .ForMember(dest => dest.ComapnyId,
                opt => opt.MapFrom(src => src.CompanyId));
        });

        return config.CreateMapper();
    }
}
