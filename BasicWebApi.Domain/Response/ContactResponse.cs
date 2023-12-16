using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebApi.Domain.Models;

namespace BasicWebApi.Domain.Response;

public class ContactResponse
{
    public int ContactId { get; set; }
    public string ContactName { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }

}
