using LojaServicos.Api.Livro.Aplicacao;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaMaterialController :  ControllerBase // Controller
    {
        private readonly IMediator _mediator;

        public LivrariaMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Criar(Novo.Executa data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LivrariaMaterialDto>>> GetLivros()
        {
            return await _mediator.Send(new ConsultaLista.Executa() );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivrariaMaterialDto>> GetLivroUnico(Guid id)
        {
            Console.WriteLine(" *** ***  Livro especifico *** *** ");
            return await _mediator.Send(new ConsultaFiltro.LivroUnico { LivroId = id } );
        }

    }
}
