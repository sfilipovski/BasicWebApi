using BasicWebApi.Domain;
using BasicWebApi.Repository.Interface;
using BasicWebApi.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Service.Implementation;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<int> CreateContact(Contact entity)
    {
        return await _contactRepository.Create(entity);
    }

    public void DeleteContact(int id)
    {
         _contactRepository.Delete(id);
    }

    public async Task<ICollection<Contact>> FilterContact(int companyId, int countryId)
    {
        return await _contactRepository.FilterContact(companyId, countryId);
    }

    public async Task<ICollection<Contact>> GetAllContacts()
    {
        return await _contactRepository.Get();
    }

    public async Task<Contact> GetContactWithCompanyAndCountry(int id)
    {
        return await _contactRepository.GetContactWithCompanyAndCountry(id);    
    }

    public async Task<Contact> UpdateCompany(Contact entity)
    {
        return await _contactRepository.Update(entity);
    }
}
