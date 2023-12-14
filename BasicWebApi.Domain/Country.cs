using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain;

public class Country
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public virtual ICollection<Contact> Contacts { get; set; }
}
