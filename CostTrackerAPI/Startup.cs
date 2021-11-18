using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CostTracker.Application.IRepositories;
using CostTracker.Application.IUOW;
using CostTracker.Application.Mappings;
using CostTracker.Application.Services.Implementation;
using CostTracker.Application.Services.Interfaces;
using CostTracker.Application.UOW;
using CostTracker.Infrastructure.Repositories;
using CostTracker.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CostTrackerAPI
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
            services.AddDbContext<CostTrackerDbContext>(builder => builder.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddScoped<DbContext, CostTrackerDbContext>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IUow, Uow>();
            services.AddAutoMapper(typeof(MaterialModels));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Configuration API",
                    Version = "v1",
                    Description = "Configuration API Description",
                });
            });

            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "CostTracker API v1");
            });

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
