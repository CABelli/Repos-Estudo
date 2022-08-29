using LojaServicos.Api.GateWay.ImplementRemote;
using LojaServicos.Api.GateWay.InterfaceRemoto;
using LojaServicos.Api.GateWay.MessageHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;

namespace LojaServicos.Api.GateWay
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
            // services.AddControllers();
            // services.AddOcelot();		  


            services.AddHttpClient("AutorService", config =>
            {
                config.BaseAddress = new Uri(Configuration["services:Autor"]);
            }
            );

            services.AddSingleton<IAutorRemoto, AutorRemoto>();

            services.AddOcelot().AddDelegatingHandler<LivroHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            await app.UseOcelot();
        }
    }
}
