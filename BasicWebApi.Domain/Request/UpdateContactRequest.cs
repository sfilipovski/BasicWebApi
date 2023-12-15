using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Request;

public class UpdateContactRequest
{
    public int ContactId { get; set; }
    public string ContactName { get; set; }
    public int CompanyId { get; set; }
    public int CountryId { get; set; }
}
