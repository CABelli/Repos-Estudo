using AutoMapper;
using LojaServicos.Api.Autor.Modelo;
using LojaServicos.Api.Autor.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                Console.WriteLine("*** *** Autor.Aplicacao - ConsultaFiltro - Handle *** *** ");

                var autor = await _contexto.AutorLivro.Where(x => x.AutorLivroGuid == request.AutorGuid).FirstOrDefaultAsync();
                
                if (autor == null)
                {
                    throw new Exception("Autor não encontrado!!!");
                }

                var autorDto = _mapper.Map<AutorLivro, AutorDto>(autor);

                return autorDto;
            }
        }
    }
}
