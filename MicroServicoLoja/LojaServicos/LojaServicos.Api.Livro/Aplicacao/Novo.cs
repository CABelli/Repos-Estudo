using FluentValidation;
using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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

            public Manejador(ContextoLivraria contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Executa request, CancellationToken cancellationToken)
            {
                //throw new NotImplementedException();

                var livro = new LivrariaMaterial
                {
                    Titulo = request.Titulo,
                    DataPublicacao = request.DataPublicacao,
                    AutorLivroGuid = request.AutorLivroGuid
                };

                _contexto.LivrariaMaterial.Add(livro);

                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Não pode inserir o livro na LivrariaMaterial");

            }
        }
    }
}
