using BasicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Repository.Interface;

public interface IContactRepository<T> : IRepository<T> where T : Contact
{
    Task<Contact> GetContactWithCompanyAndCountry(int id);
    Task<ICollection<Contact>> FilterContact(int companyId, int countryId);
}
