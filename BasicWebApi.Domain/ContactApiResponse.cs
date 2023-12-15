using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebApi.Domain.Models;

namespace BasicWebApi.Domain;

public class ContactApiResponse
{
    public int ContactId { get; set; }
    public string ContactName { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }

    public static ContactApiResponse toApiResponse(Contact c)
    {
        return new ContactApiResponse
        {
            ContactId = c.ContactId,
            ContactName = c.ContactName,
            CompanyId = c.ComapnyId,
            CountryId = c.CountryId,
            CompanyName = c.Company.CompanyName,
            CountryName = c.Country.CountryName
        };
    }
}
