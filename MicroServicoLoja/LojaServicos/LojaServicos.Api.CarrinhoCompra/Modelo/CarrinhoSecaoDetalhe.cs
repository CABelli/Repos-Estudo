using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.Modelo
{
    public class CarrinhoSecaoDetalhe
    {
        public int CarrinhoSecaoDetalheId { get; set; }

        public DateTime? DataCriacao { get; set; }

        public string ProdutoSelecionado { get; set; }

        public int CarrinhoSecaoId { get; set; }

        public CarrinhoSecao CarrinhoSecao { get; set; }
    }
}
