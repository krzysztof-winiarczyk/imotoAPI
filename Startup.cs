using imotoAPI.Entities;
using imotoAPI.Middleware;
using imotoAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imoto
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "imoto", Version = "v1" });
            });

            services.AddDbContext<ImotoDbContext>();

            services.AddScoped<ErrorHandlingMiddleware>();

            services.AddScoped<ICarFuelService, CarFuelService>();
            services.AddScoped<ICarClassService, CarClassService>();
            services.AddScoped<ICarEquipmentService, CarEquipmentService>();
            services.AddScoped<ICarDriveService, CarDriveService>();
            services.AddScoped<ICarTransmissionService, CarTransmissionService>();
            services.AddScoped<ICarYearService, CarYearService>();
            services.AddScoped<ICarColorService, CarColorService>();
            services.AddScoped<ICarStatusSerivce, CarStatusService>();
            services.AddScoped<ICarCountryService, CarCountryService>();
            services.AddScoped<ICarBodyworkService, CarBodyworkService>();
            services.AddScoped<ICarBrandService, CarBrandService>();
            services.AddScoped<ICarModelService, CarModelService>();
            services.AddScoped<IAnnoucementService, AnnoucementService>();

            services.AddScoped<IModertorTypeService, ModeratorTypeService>();
            services.AddScoped<IModeratorService, ModeratorService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPasswordHasher<Moderator>, PasswordHasher<Moderator>>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "imoto v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
