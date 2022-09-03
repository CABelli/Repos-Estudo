using LojaServicos.RabbitMQ.Bus.Eventos;
using System;

namespace LojaServicos.RabbitMQ.Bus.Comandos
{
    public abstract class Comando : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Comando()
        {
            Timestamp = DateTime.Now;
        }
    }
}
