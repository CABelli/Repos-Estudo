using System;
using System.Collections.Generic;

namespace LojaServicos.Api.CarrinhoCompra.Modelo
{
    public class CarrinhoSecao
    {
        public int CarrinhoSecaoId { get; set; }

        public DateTime? DataCriacao { get; set; }

        public ICollection<CarrinhoSecaoDetalhe> ListaDetalhe { get; set; }
    }
}
