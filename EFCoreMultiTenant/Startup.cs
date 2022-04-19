using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMultiTenant.Data;
using EFCoreMultiTenant.Middlewares;
using EFCoreMultiTenant.Models;
using EFCoreMultiTenant.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EFCoreMultiTenant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<TenantData>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EFCoreMultiTenant", Version = "v1" });
            });

            services.AddDbContext<ApplicationContext>(p=>p
                .UseSqlite("Data source=SQLiteDatabase.sqlite")
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
            );

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFCoreMultiTenant v1"));
            }

            DatabaseInitialize(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<TenantMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void DatabaseInitialize(IApplicationBuilder app)
        {
            using var _context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationContext>();

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.Customers.AddRange(
                new Customer { Name = "Microsoft", TenantId = "1"},
                new Customer { Name = "Apple", TenantId = "2"}
            );

            _context.Items.AddRange(
                new Item { Description = "Office 365 Family", SalesPrice = 45m, CustomerId=1, TenantId = "1"},
                new Item { Description = "Macbook Pro M1", SalesPrice = 19799m, CustomerId=2, TenantId = "2"},
                new Item { Description = "iPhone 13 Pro Max 128Gb", SalesPrice = 8499m, CustomerId=2, TenantId = "2"},
                new Item { Description = "iPad 11 Pro Wifi 128Gb", SalesPrice = 10799m, CustomerId=2, TenantId = "2"}
            );
            
            _context.SaveChanges();
        }

    }
}
