using LojaServicos.Api.Livro.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Persistencia
{
    public class ContextoLivraria : DbContext
    {
        // apos a classe Teste esativer quase pronta 
        // 1) criar o construtor ContextoLivraria

        public ContextoLivraria ()
        {

        }


        public ContextoLivraria(DbContextOptions<ContextoLivraria> options) : base(options) { }

        // apos a classe Teste esativer quase pronta 
        // 2) Mudar na classe ContextoLivraria no metodo DbSet para tipo virtual
       
        //public DbSet<LivrariaMaterial> LivrariaMaterial { get; set; }
        public virtual DbSet<LivrariaMaterial> LivrariaMaterial { get; set; }

    }
}
