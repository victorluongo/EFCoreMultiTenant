using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EFCoreMultiTenant.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetTenantId(this HttpContext httpContext)
        {
            var tenant = "";

            // get from domain/{tenantId}/[controller]
            if (!(httpContext.Request.Path == PathString.Empty || httpContext.Request.Path == "/"))
                tenant = httpContext.Request.Path.Value.Split('/', System.StringSplitOptions.RemoveEmptyEntries)[0];

            // get from header
            else if (httpContext.Request.Headers.ContainsKey("tenantId"))
                tenant = httpContext.Request.Headers["tenantId"];

            return tenant;
        }
            
    }
}