using LojaServicos.RabbitMQ.Bus.Comandos;
using LojaServicos.RabbitMQ.Bus.Eventos;
using System.Threading.Tasks;

namespace LojaServicos.RabbitMQ.Bus.BusRabbit
{
    public interface IRabbitEventBus
    {
        Task EnviarComando<T>(T comando) where T : Comando;
        void Publish<T>(T @evento) where T : Evento;
        void Subscribe<T, TH>() where T : Evento
                                where TH : IEventoManejador<T>;
    }
}
