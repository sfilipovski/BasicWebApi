using BasicWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Service.Interface;

public interface ICompanyService
{
    Task<ICollection<Company>> GetAllCompanies();
    Task<int> CreateCompany(Company entity);
    Task<Company> UpdateCompany(Company entity);
    void DeleteCompany(int id);
}
