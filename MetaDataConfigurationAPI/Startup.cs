using MetaDataConfigurationAPI.Client;
using MetaDataConfigurationAPI.DataBase;
using MetaDataConfigurationAPI.Repository.Interfaces;
using MetaDataConfigurationAPI.Repository.RepoClasses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaDataConfigurationAPI
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
            services.AddDbContext<EntitiesDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CONFIG_DB")));
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IReadRepository, ReadRepository>();
            services.AddScoped<ISaveRepository, SaveRepository>();
            services.AddTransient<IExternalSourcesRepository, ExternalSourcesRepository>();
            services.AddTransient<IExternalClient, ExternalClient>();
            services.AddHttpClient();
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
