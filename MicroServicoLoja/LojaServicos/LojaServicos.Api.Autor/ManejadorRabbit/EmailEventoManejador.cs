using LojaServicos.Mensageria.Email.SendGridLivraria.Interface;
using LojaServicos.Mensageria.Email.SendGridLivraria.Modelo;
using LojaServicos.RabbitMQ.Bus.BusRabbit;
using LojaServicos.RabbitMQ.Bus.EventoQueue;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.ManejadorRabbit
{
    public class EmailEventoManejador : IEventoManejador<EmailEventoQueue>
    {
        private readonly ILogger<EmailEventoManejador> _logger;
        private readonly ISendGridEnviar _sendGridEnviar;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public EmailEventoManejador() { }

        public EmailEventoManejador(ILogger<EmailEventoManejador> logger,
            ISendGridEnviar sendGridEnviar,
            Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _logger = logger;
            _sendGridEnviar = sendGridEnviar;
            _configuration = configuration; 
        }
        public async Task Handle(EmailEventoQueue @event)
        {
            Console.WriteLine($"*** *** EmailEventoManejador - Handle - livro: {@event.Titulo} *** *** ");
            _logger.LogInformation($"******  livro: {@event.Titulo} * *****  ");

            var objData = new SendGridData();
            objData.Conteudo = @event.Conteudo;
            objData.EmailDestinatario = @event.Destinatario;
            objData.NomeDestinatario = @event.Destinatario;
            objData.Titulo = @event.Titulo;
            objData.SendGridApiKey = _configuration["SendGrid:ApiKey"];

            var resultado =  await _sendGridEnviar.EnviarEmail(objData);
            if(resultado.resultado)
            {
                await Task.CompletedTask;
                return;
            }
        }
    }
}
