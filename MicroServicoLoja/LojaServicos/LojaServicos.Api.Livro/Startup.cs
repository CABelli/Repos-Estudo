using FluentValidation.AspNetCore;
using LojaServicos.Api.Livro.Aplicacao;
using LojaServicos.Api.Livro.Persistencia;
using LojaServicos.RabbitMQ.Bus.BusRabbit;
using LojaServicos.RabbitMQ.Bus.Implement;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LojaServicos.Api.Livro
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
            //services.AddTransient<IRabbitEventBus, RabbitEventBus>();

            services.AddSingleton<IRabbitEventBus, RabbitEventBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new RabbitEventBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Novo>());            

            services.AddDbContext<ContextoLivraria>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexaoDB"));
            });

            services.AddMediatR(typeof(Novo.Manejador).Assembly);

            services.AddAutoMapper(typeof(ConsultaLista.Executa));
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
