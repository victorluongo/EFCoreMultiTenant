using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMultiTenant.Models
{
    public abstract class BaseEntity
    {
        public int Id {get; set;}
        public string TenantId {get; set;}
    }
}