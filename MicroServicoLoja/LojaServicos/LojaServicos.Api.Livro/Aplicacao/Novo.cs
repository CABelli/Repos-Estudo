using FluentValidation;
using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;
using LojaServicos.RabbitMQ.Bus.BusRabbit;
using LojaServicos.RabbitMQ.Bus.EventoQueue;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class Novo
    {
        public class Executa : IRequest
        {
            public string Titulo { get; set; }

            public DateTime? DataPublicacao { get; set; }

            public Guid? AutorLivroGuid { get; set; }
        }

        public class ExecutaValidacao : AbstractValidator<Executa>
        {
            public ExecutaValidacao()
            {
                RuleFor(x => x.Titulo).NotEmpty();

                RuleFor(x => x.DataPublicacao).NotEmpty();

                RuleFor(x => x.AutorLivroGuid).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Executa>
        {
            public readonly ContextoLivraria _contexto;
            public readonly IRabbitEventBus _eventBus;

            public Manejador(ContextoLivraria contexto, IRabbitEventBus eventBus)
            {
                _contexto = contexto;
                _eventBus = eventBus;
            }

            public async Task<Unit> Handle(Executa request, CancellationToken cancellationToken)
            {
                Console.WriteLine(" *** ***  class Novo/Manejador - Handle *** *** ");
                var livro = new LivrariaMaterial
                {
                    Titulo = request.Titulo,
                    DataPublicacao = request.DataPublicacao,
                    AutorLivroGuid = request.AutorLivroGuid
                };

                _contexto.LivrariaMaterial.Add(livro);

                var valor = await _contexto.SaveChangesAsync();

                _eventBus.Publish(new EmailEventoQueue("cesar.belli@hotmail.com",
                    request.Titulo,
                    "Esse conteudo é um exemplo"));

                if (valor > 0)
                {
                    Console.WriteLine(" *** ***  class Novo/Manejador - Handle - Sucesso *** *** ");
                    return Unit.Value;
                }

                Console.WriteLine(" *** ***  class Novo/Manejador - Handle - Zebra *** *** ");
                throw new Exception("Não pode inserir o livro na LivrariaMaterial");
            }
        }
    }
}
