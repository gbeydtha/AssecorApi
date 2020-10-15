using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssecorApi.Data;
using AssecorApi.Data.Interfaces;
using AssecorApi.Data.Mock;
using AssecorApi.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AssecorApi
{
    public class Startup
    {


        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {

            //Server configuration
            services.AddDbContext<AddDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Entity Framworks
            // Following two service register are for Entity Framworks
            // commented the following two lines When use Mock Data or data from CSV file

            //services.AddScoped<IPersonRepository, PersonRepository>();
            //services.AddScoped<IColorRepository, ColorRepository>();


            // CSV 
            // Following two service register are for Mock Data or reading data from CSV file
            // Uncommented the following two lines When use Entity Framworks

            services.AddScoped<IPersonRepository, MockPersonRepository>();
            services.AddScoped<IColorRepository, MockColorRepository>();
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

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
