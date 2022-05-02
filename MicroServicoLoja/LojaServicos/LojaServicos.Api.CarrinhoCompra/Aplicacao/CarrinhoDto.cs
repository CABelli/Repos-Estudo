using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.Aplicacao
{
    public class CarrinhoDto
    {
        public int  CarrinhoId { get; set; }

        public DateTime? DataCriacaoSecao { get; set; }

        public List<CarrinhoDetalheDto> ListaProdutos { get; set; }

    }
}
