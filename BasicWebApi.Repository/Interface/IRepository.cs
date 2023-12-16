using BasicWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Repository.Interface;

public interface IRepository<T> where T : class
{
    Task<ICollection<T>> Get();
    Task<int> Create(T entity);
    Task<T> Update(T entity);
    void Delete(int id);
}
