using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Response;

public class CountryResponse
{
    public string CountryName { get; set; }
    public List<ContactNameResponse> Contacts { get; set; }
}
