using LojaServicos.Api.CarrinhoCompra.Aplicacao;
using LojaServicos.Api.CarrinhoCompra.Persistencia;
using LojaServicos.Api.CarrinhoCompra.RemoteInterface;
using LojaServicos.Api.CarrinhoCompra.RemoteService;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace LojaServicos.Api.CarrinhoCompra
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
            services.AddScoped<ILivroService, LivroService>();

            services.AddControllers();

            services.AddDbContext<CarrinhoContexto>(options =>
            {
                //options.UseMySQL(Configuration.GetConnectionString("ConexaoDataBase"));
                options.UseMySQL(Configuration.GetConnectionString("ConexaoDataBase"));
            });

            services.AddMediatR(typeof(Novo.Manejador).Assembly);

            services.AddHttpClient("Livros", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Livros"]);
                }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
