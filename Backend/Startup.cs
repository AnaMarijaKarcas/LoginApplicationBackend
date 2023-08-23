
﻿using Backend.Data;
using Backend.Interfaces;
using Backend.Cryptography;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Backend.Repo;
using Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var secretsConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build();
            Configuration = new ConfigurationBuilder()
                .AddConfiguration(Configuration)
                .AddConfiguration(secretsConfig)
                .Build();
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDbRepo, DbRepo>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IValidateService, ValidateService>();
            services.AddScoped<ICryptography, Cryptography.Cryptography>();
            services.AddScoped<IValidateService, ValidateService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(o => {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateAudience = false,
                      ValidateIssuer = false,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSigningKey"]))
                  };
              });
            //Add DbContext
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BackendAppConnectionString")));

            //Add CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            services.AddControllers();

            services.AddMvc();


            //services.AddCors(c =>
            //{
            //    c.AddDefaultPolicy(builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            //    });
            //    //c.AddPolicy("AllowsOrigin", options => options.WithOrigins("http://localhost:4200/*").AllowAnyMethod()
            //    //.AllowAnyHeader());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseCors("AllowAngularOrigins");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        
    }
}
