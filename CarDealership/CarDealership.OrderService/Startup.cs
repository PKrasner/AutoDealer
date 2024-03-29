using CarDealership.OrderService.Consumers;
using CarDealership.OrderService.Data;
using MassTransit;
using MassTransit.Definition;
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
using System.Net.Http;
using System.Threading.Tasks;

namespace CarDealership.OrderService
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
            services.AddHttpClient<CatalogService>(x =>
            {
                x.BaseAddress = new Uri(Configuration["ExternalServices:CatalogService:Url"]);
            });

            services.AddControllers();

            var massTransitSection = Configuration.GetSection("MassTransit");
            var url = massTransitSection.GetValue<string>("Url");
            var host = massTransitSection.GetValue<string>("Host");
            var userName = massTransitSection.GetValue<string>("UserName");
            var password = massTransitSection.GetValue<string>("Password");

            services.AddMassTransit(x =>
            {
                x.AddConsumer<OrderCreatedConsumer>();

                x.SetSnakeCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host($"rabbitmq://{url}/{host}", configurator =>
                    {
                        configurator.Username(userName);
                        configurator.Password(password);
                    });

                    cfg.AutoDelete = false;
                    cfg.Durable = true;
                    cfg.Exclusive = false;
                    //cfg.ClearMessageDeserializers();
                    //cfg.UseRawJsonSerializer();
                    cfg.ConfigureEndpoints(context, SnakeCaseEndpointNameFormatter.Instance);
                });
            });

            services.AddMassTransitHostedService();

            services.AddDbContext<OrderContext>(options =>
               options
               .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))
               .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
               );

            services.AddAutoMapper(typeof(Startup));
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
