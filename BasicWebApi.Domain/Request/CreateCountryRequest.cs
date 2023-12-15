using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Request;

public class CreateCountryRequest
{
    public string CountryName { get; set; }
}
