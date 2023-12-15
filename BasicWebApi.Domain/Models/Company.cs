using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.Models;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public virtual ICollection<Contact> Contacts { get; set; }
}
