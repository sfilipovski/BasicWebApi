using BasicWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Service.Interface;

public interface IContactService
{
    Task<ICollection<Contact>> GetAllContacts();
    Task<int> CreateContact(Contact entity);
    Task<Contact> UpdateCompany(Contact entity);
    void DeleteContact(int id);
    Task<Contact> GetContactWithCompanyAndCountry(int id);
    Task<ICollection<Contact>> FilterContact(int companyId, int countryId);
}
