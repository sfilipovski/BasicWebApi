using BasicWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Repository.Interface;

public interface IContactRepository
{
    Task<ICollection<Contact>> Get();
    Task<int> Create(Contact entity);
    Task<Contact> Update(Contact entity);
    void Delete(int id);
    Task<Contact> GetContactWithCompanyAndCountry(int id);
    Task<ICollection<Contact>> FilterContact(int companyId, int countryId);
}
