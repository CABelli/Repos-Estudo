using AutoMapper;
using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class ConsultaFiltro
    {
        public class LivroUnico : MediatR.IRequest<LivrariaMaterialDto>
        {
            public Guid? LivroId { get; set; }
        }

        public class Manejador : IRequestHandler<LivroUnico, LivrariaMaterialDto>
        {
            private readonly ContextoLivraria _contexto;

            private readonly IMapper _mapper;

            public Manejador(ContextoLivraria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LivrariaMaterialDto> Handle(LivroUnico request, CancellationToken cancellationToken)
            {
                Console.WriteLine("*** *** Livro.Aplicacao - ConsultaFiltro/Manejador Handle *** ***");
                var livro = await _contexto.LivrariaMaterial.Where( x => x.LivrariaMaterialId == request.LivroId).FirstOrDefaultAsync();

                if (livro == null)
                {
                    throw new Exception("Livro não encontrado");
                }

                var livroDto = _mapper.Map<LivrariaMaterial, LivrariaMaterialDto>(livro);

                return livroDto;
            }
        }
    }
}
