
﻿using Backend.Data;
using Backend.Interfaces;

﻿using System;
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

namespace Backend
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
            
            services.AddScoped<IDbRepo, DbRepo>();
            services.AddScoped<IUserService, UserService>();
           
            services.AddScoped<IValidateService, ValidateService>();
            services.AddScoped<ICryptography, Cryptography.Cryptography>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        
    }
}
