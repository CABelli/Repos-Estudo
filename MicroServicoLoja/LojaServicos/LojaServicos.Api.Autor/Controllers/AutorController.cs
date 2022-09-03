using LojaServicos.Api.Autor.Aplicacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AutorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Criar(Novo.Executa data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorDto>>> GetAutores()
        {
            Console.WriteLine("*** *** AutorController - GetAutores *** *** ");
            return await _mediator.Send(new Consulta.ListaAutor());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutorLivro(string id)
        {
            Console.WriteLine("*** *** AutorController - GetAutorLivro *** *** ");
            return await _mediator.Send(new ConsultaFiltro.AutorUnico { AutorGuid = id });

        }
    }
}
