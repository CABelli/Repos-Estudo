using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.Aplicacao
{
    public class CarrinhoDetalheDto
    {
        public Guid? LivroId { get; set; }

        public string TituloLivro { get; set; }

        public string AutorLivro { get; set; }

        public DateTime? DataPublicacao { get; set; }

    }
}
