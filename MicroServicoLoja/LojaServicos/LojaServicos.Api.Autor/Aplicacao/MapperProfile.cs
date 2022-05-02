using AutoMapper;
using LojaServicos.Api.Autor.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Autor.Aplicacao
{
    public class MapperProfile : Profile 
    {
        public MapperProfile()
        {
            CreateMap<AutorLivro, AutorDto>();
        }

    }
}
