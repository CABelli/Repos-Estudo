using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class AutorDto
    {
        public string Nome { get; set; }

        public string Apelido { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string AutorLivroGuid { get; set; }
    }
}
