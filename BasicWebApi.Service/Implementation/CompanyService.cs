using BasicWebApi.Domain.Models;
using BasicWebApi.Repository.Interface;
using BasicWebApi.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Service.Implementation;

public class CompanyService : ICompanyService
{
    private readonly IRepository<Company> _companyRepository;

    public CompanyService(IRepository<Company> companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<int> CreateCompany(Company entity)
    {
        return await _companyRepository.Create(entity);
    }

    public void DeleteCompany(int id)
    {
        _companyRepository.Delete(id);
    }

    public async Task<ICollection<Company>> GetAllCompanies()
    {
        return await _companyRepository.Get();
    }

    public async Task<Company> UpdateCompany(Company entity)
    {
        return await _companyRepository.Update(entity);
    }
}
