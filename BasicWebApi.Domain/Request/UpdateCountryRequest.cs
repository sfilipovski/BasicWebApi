using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Request;

public class UpdateCountryRequest
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
}
