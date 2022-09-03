using LojaServicos.Api.Livro.Aplicacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            Console.WriteLine(" *** ***  Livro.Controllers - Criar *** *** ");
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LivrariaMaterialDto>>> GetLivros()
        {
            Console.WriteLine(" *** ***  Livro.Controllers - GetLivros *** *** ");
            return await _mediator.Send(new ConsultaLista.Executa() );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivrariaMaterialDto>> GetLivroUnico(Guid id)
        {
            Console.WriteLine(" *** ***  Livro.Controllers - GetLivroUnico *** *** ");
            return await _mediator.Send(new ConsultaFiltro.LivroUnico { LivroId = id } );
        }
    }
}
