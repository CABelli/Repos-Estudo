using FluentValidation;
using LojaServicos.Api.Autor.Modelo;
using LojaServicos.Api.Autor.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class Novo
    {
        public class Executa : IRequest
        {

            public string Nome { get; set; }

            public string Apelido { get; set; }

            public DateTime? DataNascimento { get; set; }

        }

        public class ExecutaValidacao : AbstractValidator<Executa>
        {

            public ExecutaValidacao()
            {
                RuleFor(x => x.Nome).NotEmpty();

                RuleFor(x => x.Apelido).NotEmpty();

            }

        }

        public class Manejador : IRequestHandler<Executa>
        {
            public readonly ContextoAutor _contexto;

            public Manejador(ContextoAutor contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Executa request, CancellationToken cancellationToken)
            {
                //throw new NotImplementedException();

                var autorLivro = new AutorLivro
                {
                    Nome = request.Nome,
                    DataNascimento = request.DataNascimento,
                    Apelido = request.Apelido,
                    AutorLivroGuid = Convert.ToString(Guid.NewGuid())
                };

                _contexto.AutorLivro.Add(autorLivro);

                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0 )
                {
                    return Unit.Value;
                }

                throw new Exception("Não pode inserir o autor do livro");

            }
        }
    }
}
