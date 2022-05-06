using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Modelo
{
    public class AutorLivro
    {
        public int AutorLivroId { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public DateTime? DataNascimento { get; set; }

        public ICollection<GrauAcademico> GrauAcademicos { get; set; }

        public string AutorLivroGuid { get; set; }

        ///   ambev 0605 14:14
    }
}
