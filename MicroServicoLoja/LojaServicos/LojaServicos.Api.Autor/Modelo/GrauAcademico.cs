using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Modelo
{
    public class GrauAcademico
    {
        public int GrauAcademicoId { get; set; }

        public string Nome { get; set; }

        public string CentroAcademico { get; set; }

        public DateTime? DataGrau { get; set; }

        public int AutorLivroId { get; set; }

        public AutorLivro AutorLivro { get; set; }

        // postgreen fica string 
        // XXXXXXX
        public string GrauAcademicoGuid { get; set; }
    }
}

