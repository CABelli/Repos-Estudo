using LojaServicos.Api.CarrinhoCompra.Modelo;
using Microsoft.EntityFrameworkCore;

namespace LojaServicos.Api.CarrinhoCompra.Persistencia
{
    public class CarrinhoContexto : DbContext
    {
        public CarrinhoContexto (DbContextOptions<CarrinhoContexto> options) : base(options) {  }

        public DbSet<CarrinhoSecao> CarrinhoSecao { get; set; }

        public DbSet<CarrinhoSecaoDetalhe> CarrinhoSecaoDetalhe { get; set; }
    }
}
