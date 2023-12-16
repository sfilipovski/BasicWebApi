using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Response;

public class CompanyResponse
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public List<ContactNameResponse> Contacts { get; set; }
}
