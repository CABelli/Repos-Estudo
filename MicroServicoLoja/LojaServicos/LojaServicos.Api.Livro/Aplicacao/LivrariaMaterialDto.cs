using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class LivrariaMaterialDto
    {
        public Guid? LivrariaMaterialId { get; set; }

        public string Titulo { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public Guid? AutorLivroGuid { get; set; }
    }
}
