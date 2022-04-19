using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMultiTenant.Models
{
    public class Customer : BaseEntity
    {
        public string Name {get; set;}
    }
}