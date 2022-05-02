using AutoMapper;
using LojaServicos.Api.Livro.Aplicacao;
using LojaServicos.Api.Livro.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaServicos.Api.Livro.Tests
{
    public class MappingTest : Profile 
    {
        public MappingTest()
        {
            CreateMap<LivrariaMaterial, LivrariaMaterialDto>();

        }
    }
}
