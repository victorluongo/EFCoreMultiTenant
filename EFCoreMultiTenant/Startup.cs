using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreMultiTenant.Data;
using EFCoreMultiTenant.Models;
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

            for(var i=1; i<=5; i++)
            {
                _context.Customers.Add(new Customer {
                    Name = $"Customer #{i}"
                });

                _context.Items.Add(new Item {
                    Description = $"Item #{i}",
                    SalesPrice = Convert.ToDecimal(i)
                });                
            }
            
            _context.SaveChanges();
        }

    }
}
