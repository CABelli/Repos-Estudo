using System;

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
