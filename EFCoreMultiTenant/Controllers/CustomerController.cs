using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMultiTenant.Data;
using EFCoreMultiTenant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreMultiTenant.Controllers
{
    [ApiController]
    [Route("{tenantId}/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Customer>Get([FromServices]ApplicationContext _context)
        {
            var customers = _context.Customers.Include(p => p.Items).ToArray();

            return customers;
        }
    }
}
