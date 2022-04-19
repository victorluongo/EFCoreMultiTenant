using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMultiTenant.Models
{
    public class Item : BaseEntity
    {
        public string Description {get; set;}
        public decimal SalesPrice {get; set;}     
        public int CustomerId {get; set;}   
        public Customer Customer {get; set;}
    }
}