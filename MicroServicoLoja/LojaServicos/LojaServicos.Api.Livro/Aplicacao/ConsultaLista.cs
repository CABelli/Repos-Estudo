using AutoMapper;
using LojaServicos.Api.Livro.Modelo;
using LojaServicos.Api.Livro.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class ConsultaLista
    {
        public class Executa : IRequest <List <LivrariaMaterialDto> > { }

        public class Manejador : IRequestHandler<Executa, List<LivrariaMaterialDto>>
        {
            private readonly ContextoLivraria _contexto;

            private readonly IMapper _mapper;

            public Manejador(ContextoLivraria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<LivrariaMaterialDto>> Handle(Executa request, CancellationToken cancellationToken)
            {
                var livros = await _contexto.LivrariaMaterial.ToListAsync();
                var livrosDto = _mapper.Map<List<LivrariaMaterial>, List<LivrariaMaterialDto>>(livros);

                return livrosDto;
            }
        }
    }
}
