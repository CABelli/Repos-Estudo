using LojaServicos.RabbitMQ.Bus.BusRabbit;
using LojaServicos.RabbitMQ.Bus.Comandos;
using LojaServicos.RabbitMQ.Bus.Eventos;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaServicos.RabbitMQ.Bus.Implement
{
    public class RabbitEventBus : IRabbitEventBus
    {
        private readonly IMediator _mediator;
        private readonly Dictionary<string, List<Type>> _manejadores;
        private readonly List<Type> _eventoTipos;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitEventBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _manejadores = new Dictionary<string, List<Type>>();
            _eventoTipos = new List<Type>();
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task EnviarComando<T>(T comando) where T : Comando
        {
            Console.Write("RabbitEventBus - EnviarComando");
            return _mediator.Send(comando);
        }

        public void Publish<T>(T @evento) where T : Evento
        {
            Console.Write("RabbitEventBus - Publish");
            var factory = new ConnectionFactory() { HostName = "rabbit-belli-web" };

            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                var eventName = evento.GetType().Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(evento);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
            }
        }

        public void Subscribe<T, TH>() where T : Evento
                                where TH : IEventoManejador<T>
        {
            Console.Write("RabbitEventBus - Subscribe");
            var eventoName = typeof(T).Name;
            var manejadorEventoTipo = typeof(TH);

            if (!_eventoTipos.Contains(typeof(T)))
            {
                _eventoTipos.Add(typeof(T));
            }

            if (!_manejadores.ContainsKey(eventoName))
            {
                _manejadores.Add(eventoName, new List<Type>());
            }

            if (_manejadores[eventoName].Any(x => x.GetType() == manejadorEventoTipo))
            {
                throw new ArgumentException($"O manejador {manejadorEventoTipo.Name} foi registrado anteriormente por {eventoName} ");
            }

            _manejadores[eventoName].Add(manejadorEventoTipo);

            var factory = new ConnectionFactory() 
            {
                HostName = "rabbit-belli-web",
                DispatchConsumersAsync = true       
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(eventoName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.Received += Consumer_Delegate;

            channel.BasicConsume(eventoName, true, consumer);
        }

        private async Task Consumer_Delegate(object sender, BasicDeliverEventArgs e)
        {
            Console.Write("RabbitEventBus - Consumer_Delegate");
            var nomeEvento = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                if (_manejadores.ContainsKey(nomeEvento))
                {
                    using(var scope = _serviceScopeFactory.CreateScope())
                    {
                        var subscriptions = _manejadores[nomeEvento];
                        foreach (var sb in subscriptions)
                        {
                            var manejador = scope.ServiceProvider.GetService(sb);   //Activator.CreateInstance(sb);

                            if (manejador == null) continue;

                            var tipoEvento = _eventoTipos.SingleOrDefault(x => x.Name == nomeEvento);
                            var eventoDS = JsonConvert.DeserializeObject(message, tipoEvento);

                            var concretoTipo = typeof(IEventoManejador<>).MakeGenericType(tipoEvento);

                            await (Task)concretoTipo.GetMethod("Handle").Invoke(manejador, new object[] { eventoDS });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("metodo Consumer_Delegate erro: " + ex);
            }
        }
    }
}
