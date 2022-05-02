using LojaServicos.Api.CarrinhoCompra.Aplicacao;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoComprasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarrinhoComprasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Criar(Novo.Executa data)
        {
            return await _mediator.Send(data);
            //return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<Unit>> Get01(Novo.Executa data)
        {
            return await _mediator.Send(data);
            //return Ok();
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<CarrinhoDto>> GetCarrinho (int id)
        {
            return await _mediator.Send(new Consulta.Executa { CarrinhoSecaoId = id });

        }

    }
}
