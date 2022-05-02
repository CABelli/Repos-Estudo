﻿using LojaServicos.Api.CarrinhoCompra.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.Persistencia
{
    public class CarrinhoContexto : DbContext
    {
        public CarrinhoContexto (DbContextOptions<CarrinhoContexto> options) : base(options) {  }

        public DbSet<CarrinhoSecao> CarrinhoSecao { get; set; }

        public DbSet<CarrinhoSecaoDetalhe> CarrinhoSecaoDetalhe { get; set; }
    }
}
