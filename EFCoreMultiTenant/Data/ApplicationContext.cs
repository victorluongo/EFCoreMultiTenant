using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCoreMultiTenant.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMultiTenant.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Item> Items {get; set;}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}