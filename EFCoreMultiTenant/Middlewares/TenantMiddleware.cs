using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMultiTenant.Extensions;
using EFCoreMultiTenant.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreMultiTenant.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next) 
        {
            _next = next;    
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var tenant = httpContext.RequestServices.GetRequiredService<TenantData>();

            tenant.TenantId = httpContext.GetTenantId();

            await _next(httpContext); 
        }           
    }
}