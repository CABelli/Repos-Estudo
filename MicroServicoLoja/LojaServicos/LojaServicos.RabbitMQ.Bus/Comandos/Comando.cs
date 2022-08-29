using LojaServicos.RabbitMQ.Bus.Eventos;
using System;
using System.Collections.Generic;
using System.Text;

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
