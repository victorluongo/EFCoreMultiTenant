using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreMultiTenant.Models;
using EFCoreMultiTenant.Providers;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMultiTenant.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Item> Items {get; set;}

        private readonly TenantData _tenant;

        public ApplicationContext
        (
            DbContextOptions<ApplicationContext> options,
            TenantData tenant
        ) : base(options)
        {
            _tenant = tenant;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasQueryFilter(p => p.TenantId == _tenant.TenantId);
            modelBuilder.Entity<Item>().HasQueryFilter(p => p.TenantId == _tenant.TenantId);
        }
    }
}