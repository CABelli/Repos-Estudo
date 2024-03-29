﻿using MediatR;

namespace LojaServicos.RabbitMQ.Bus.Eventos
{
    public abstract class Message :IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
