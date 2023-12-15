using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebApi.Domain.Models;

namespace BasicWebApi.Domain.Response;

public class ContactResponse
{
    public string ContactName { get; set; }
    public string CompanyName { get; set; }
    public string CountryName { get; set; }

}
