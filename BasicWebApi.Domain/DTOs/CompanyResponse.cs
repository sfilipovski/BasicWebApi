using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.DTOs;

public class CompanyResponse
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public List<ContactResponse> Contacts { get; set; }
}
