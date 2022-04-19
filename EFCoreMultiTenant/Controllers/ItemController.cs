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
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Item>Get([FromServices]ApplicationContext _context)
        {
            var items = _context.Items.Include(p => p.Customer).ToList();

            return items;
        }
    }
}
