﻿using LojaServicos.RabbitMQ.Bus.Eventos;
using System.Threading.Tasks;

namespace LojaServicos.RabbitMQ.Bus.BusRabbit
{
    public interface IEventoManejador<in TEvent> : IEventoManejador where TEvent : Evento
    {
        Task Handle(TEvent @event);
    }

    public interface IEventoManejador
    {
    }
}
