using LojaServicos.Api.Livro.Modelo;
using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.Livro.Persistencia
{
    public class ContextoLivraria : DbContext
    {
        public ContextoLivraria ()
        {

        }

        public ContextoLivraria(DbContextOptions<ContextoLivraria> options) : base(options) { }
               
        public virtual DbSet<LivrariaMaterial> LivrariaMaterial { get; set; }
    }
}
