﻿using BasicWebApi.Domain.Models;
using BasicWebApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Repository.Implementation;

public class CountryRepository : IRepository<Country>
{
    private readonly ApplicationDbContext _context;

    public CountryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Country entity)
    {
        var result = await _context.Set<Country>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return result != null ? 1 : 0;
    }

    public void Delete(int id)
    {
        var result = _context.Set<Country>().FirstOrDefault(c => c.CountryId == id);

        if (result == null) return;
        
        _context.Set<Country>().Remove(result);
        _context.SaveChanges();
        
    }

    public async Task<ICollection<Country>> Get()
    {
        return await _context.Set<Country>()
            .AsNoTracking()
            .Include(c => c.Contacts)
            .ToListAsync();
    }

    public async Task<Country> Update(Country entity)
    {
        var result = await _context.Set<Country>()
            .Include(c => c.Contacts)
            .FirstOrDefaultAsync(c => c.CountryId == entity.CountryId);

        if (result == null) return null;
        
        result.CountryName = entity.CountryName;
        await _context.SaveChangesAsync();
        
        return result;
    }
}
