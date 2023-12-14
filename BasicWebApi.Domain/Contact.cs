using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain;

public class Contact
{
    public int ContactId { get; set; }
    public string ContactName { get; set; }
    public virtual Company Company { get; set; }
    public int ComapnyId { get; set; }
    public virtual Country Country { get; set; }
    public int CountryId { get; set; }
}
