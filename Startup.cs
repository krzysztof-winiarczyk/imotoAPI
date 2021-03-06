using imotoAPI;
using imotoAPI.Entities;
using imotoAPI.Middleware;
using imotoAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //--authentication
            var authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings);

            services.AddSingleton(authenticationSettings);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
                };
            });
            //--authentication

            //services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();

            services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "imoto", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddDbContext<ImotoDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("ImotoDbConnection")));

            //seeders
            services.AddScoped<ImotoSeeder>();

            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddResponseCaching();

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

            services.AddScoped<IModeratorService, ModeratorService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IWatchedUserService, WatchedUserService>();

            services.AddScoped<IWatchedAnnoucementService, WatchedAnnoucementService>();

            services.AddScoped<IPasswordHasher<Moderator>, PasswordHasher<Moderator>>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddScoped<IUserStatusService, UserStatusService>();
            services.AddScoped<IModeratorStatusService, ModeratorStatusService>();
            services.AddScoped<IAnnoucementStatusService, AnnoucementStatusService>();

            services.AddScoped<IVoivodeshipService, VoivodeshipService>();

            services.AddScoped<IImageService, ImageService>();

            //helpers
            services.AddScoped<IAnnoucementServiceHelper, AnnoucementServiceHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ImotoSeeder seeder)
        {
            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "imoto v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
