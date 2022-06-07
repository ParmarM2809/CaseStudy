using Confluent.Kafka;
using MassTransit;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using UserService.Events;
using Utility;

namespace UserService
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

            var producerConfig = new ProducerConfig();
            Configuration.Bind("producer", producerConfig);
            services.AddSingleton<ProducerConfig>(producerConfig);
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "www.compilemode.com", Version = "v1" });
            });
            //RabbitMQ
            //services.AddMassTransit(x =>
            //{
            //    x.UsingRabbitMq((context, cfg) =>
            //    {
            //        var uri = new Uri(Configuration["ServiceBus:Uri"]);
            //        cfg.Host(uri, host =>
            //        {
            //            host.Username(Configuration["ServiceBus:Username"]);
            //            host.Password(Configuration["ServiceBus:Password"]);
            //        });
            //    });
            //});

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
                x.AddRider(rider =>
                {
                    rider.AddProducer<SeatBookingDeletation>(nameof(SeatBookingDeletation));
                    rider.UsingKafka((context, k) =>
                    {
                        k.Host("localhost:9092");
                        k.TopicEndpoint<SeatBookingCreation>(nameof(SeatBookingCreation),
                            GetUniqueName(nameof(SeatBookingCreation)), e =>
                            {
                                e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            });
                    });

                });
            });
            services.AddConsulConfig(Configuration);
            services.AddMassTransitHostedService();

        }

        private string GetUniqueName(string EventName)
        {
            string hostName = Dns.GetHostName();
            string classAssembly = Assembly.GetCallingAssembly().GetName().Name;
            return $"{hostName}.{classAssembly}.{EventName}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "My API V1"); //originally "./swagger/v1/swagger.json"
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDeveloperExceptionPage();

            app.UseConsul(Configuration);
        }
    }
}
