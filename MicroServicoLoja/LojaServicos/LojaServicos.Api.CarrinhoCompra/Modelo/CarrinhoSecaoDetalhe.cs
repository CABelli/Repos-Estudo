using System;

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
