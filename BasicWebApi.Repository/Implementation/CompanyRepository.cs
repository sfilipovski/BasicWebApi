﻿using BasicWebApi.Domain.Models;
using BasicWebApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Repository.Implementation;

public class CompanyRepository : IRepository<Company>
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Company entity)
    {
        var result = await _context.Set<Company>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return result != null ? 1 : 0;
    }

    public void Delete(int id)
    {
        var result = _context.Set<Company>().FirstOrDefault(c => c.CompanyId == id);

        if (result == null) return;
       
        _context.Set<Company>().Remove(result);
        _context.SaveChanges();
    }

    public async Task<ICollection<Company>> Get()
    {
        return await _context.Set<Company>()
            .AsNoTracking()
            .Include(c => c.Contacts)
            .ToListAsync();
    }

    public async Task<Company> Update(Company entity)
    {
        var result = await _context.Set<Company>()
            .Include(c => c.Contacts)
            .FirstOrDefaultAsync(c => c.CompanyId == entity.CompanyId);

        if (result == null) return null;

        result.CompanyName = entity.CompanyName;
        await _context.SaveChangesAsync();

        return result;
    }
}
