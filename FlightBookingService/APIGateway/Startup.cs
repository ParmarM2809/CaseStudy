using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddOcelot().AddConsul();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseAuthorization();
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            app.UseOcelot().Wait();
        }
    }
}