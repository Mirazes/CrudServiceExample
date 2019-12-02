using ServiceExample.ApplicationCore.Interfaces;
using ServiceExample.ApplicationCore.Services;
using ServiceExample.Entity.Interfaces;
using ServiceExample.Entity.LiteDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceExample.Web
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
            services.AddMvc();
            // Dependency injections. Here you can define databases you like to use.
            services.AddTransient<IDatabase, LiteDb>();
            services.AddScoped<IFactoryDeviceService, FactoryDeviceService>();
            services.AddScoped<IFactoryMaintenanceTaskService, FactoryMaintenanceTaskServiceService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}