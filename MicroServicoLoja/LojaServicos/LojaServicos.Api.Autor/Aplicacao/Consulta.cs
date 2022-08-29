using AutoMapper;
using LojaServicos.Api.Autor.Modelo;
using LojaServicos.Api.Autor.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDto>> { }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                // throw new NotImplementedException();
                
                var autores = await _contexto.AutorLivro.ToListAsync();
                //List<AutorDto> autoresDto = null; 
                var autoresDto = _mapper.Map<List<AutorLivro>, List<AutorDto>>(autores) ;

                return autoresDto;
            }
        }
    }
}
