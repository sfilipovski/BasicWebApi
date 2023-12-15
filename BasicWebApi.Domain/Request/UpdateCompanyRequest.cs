using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Request;

public class UpdateCompanyRequest
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
}
