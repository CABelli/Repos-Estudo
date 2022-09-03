using FluentValidation.AspNetCore;
using LojaServicos.Api.Autor.Aplicacao;
using LojaServicos.Api.Autor.ManejadorRabbit;
using LojaServicos.Api.Autor.Persistencia;
using LojaServicos.Mensageria.Email.SendGridLivraria.Implement;
using LojaServicos.Mensageria.Email.SendGridLivraria.Interface;
using LojaServicos.RabbitMQ.Bus.BusRabbit;
using LojaServicos.RabbitMQ.Bus.EventoQueue;
using LojaServicos.RabbitMQ.Bus.Implement;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LojaServicos.Api.Autor
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
            services.AddSingleton<IRabbitEventBus, RabbitEventBus>( sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new RabbitEventBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddSingleton<ISendGridEnviar, SendGridEnviar>();

            services.AddTransient<EmailEventoManejador>();

            services.AddTransient<IEventoManejador<EmailEventoQueue>, EmailEventoManejador>();

            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Novo>());

            services.AddDbContext<ContextoAutor>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("ConexaoDatabase"));
            });

            services.AddMediatR(typeof(Novo.Manejador).Assembly);
            services.AddAutoMapper(typeof(Consulta.ListaAutor));
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

            var eventBus = app.ApplicationServices.GetRequiredService<IRabbitEventBus>();
            eventBus.Subscribe<EmailEventoQueue, EmailEventoManejador>();
        }
    }
}
