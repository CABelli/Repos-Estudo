using LojaServicos.Api.Autor.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Persistencia
{
    public class ContextoAutor : DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options) : base(options) { }

        public DbSet<AutorLivro> AutorLivro { get; set; }

        public DbSet<GrauAcademico> GrauAcademico { get; set; }
    }
}
