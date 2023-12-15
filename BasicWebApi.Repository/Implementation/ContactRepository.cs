using BasicWebApi.Domain.Models;
using BasicWebApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Repository.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Contact entity)
        {
            var result = await _context.Set<Contact>().AddAsync(entity);

            await _context.SaveChangesAsync();
            return result != null ? 1 : 0;
        }

        public void Delete(int id)
        {
            var result = _context.Set<Contact>().FirstOrDefault(c => c.ContactId == id);

            if (result != null)
            {
                _context.Set<Contact>().Remove(result);
                _context.SaveChanges();
            }
        }

        public async Task<ICollection<Contact>> FilterContact(int companyId, int countryId)
        {
            var result = await _context.Set<Contact>()
                .Include(c => c.Company)
                .Include(c => c.Country)
                .Where(c => c.ComapnyId == companyId || c.CountryId == countryId)
                .ToListAsync();

            if (result == null) return new List<Contact>();

            return result;
        }

        public async Task<ICollection<Contact>> Get()
        {
            return await _context.Set<Contact>()
                .AsNoTracking()
                .Include(x => x.Country)
                .Include(x => x.Company)
                .ToListAsync();
        }

        public async Task<Contact> GetContactWithCompanyAndCountry(int id)
        {
            var result = await _context.Set<Contact>()
                .Include(c => c.Company)
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.ContactId == id);
            
            if(result != null) return result;

            return null;

        }

        public async Task<Contact> Update(Contact entity)
        {
            var result = await _context.Set<Contact>().FirstOrDefaultAsync(c => c.ContactId == entity.ContactId);

            if (result != null)
            {
                result.ContactName = entity.ContactName;
                result.ComapnyId = entity.ComapnyId;
                result.Company =  _context.Set<Company>().FirstOrDefault(c => c.CompanyId == entity.ComapnyId)!;
                result.CountryId = entity.CountryId;
                result.Country = _context.Set<Country>().FirstOrDefault(c => c.CountryId == entity.CountryId)!;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
