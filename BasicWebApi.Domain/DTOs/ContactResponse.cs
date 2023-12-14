using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Domain.DTOs;

public class ContactResponse
{
    public int ContactId { get; set; }
    public string ContactName { get; set; }
}
