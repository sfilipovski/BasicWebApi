using BasicWebApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebApi.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    DbSet<Company> Companies { get; set; }
    DbSet<Contact> Contacts { get; set; }
    DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .Property(e => e.CompanyId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Contact>()
            .Property(e => e.ContactId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Country>()
            .Property(e => e.CountryId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Contact>()
            .HasOne<Company>(c => c.Company)
            .WithMany(c => c.Contacts)
            .HasForeignKey(c => c.ComapnyId)
            .IsRequired();

        modelBuilder.Entity<Contact>()
            .HasOne<Country>(c => c.Country)
            .WithMany(c => c.Contacts)
            .HasForeignKey(c => c.CountryId)
            .IsRequired();
        //base.OnModelCreating(modelBuilder);
    }
}
