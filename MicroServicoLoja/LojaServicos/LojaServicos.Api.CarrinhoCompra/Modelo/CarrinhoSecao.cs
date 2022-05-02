using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.Modelo
{
    public class CarrinhoSecao
    {
        public int CarrinhoSecaoId { get; set; }

        public DateTime? DataCriacao { get; set; }

        public ICollection<CarrinhoSecaoDetalhe> ListaDetalhe { get; set; }
    }
}
