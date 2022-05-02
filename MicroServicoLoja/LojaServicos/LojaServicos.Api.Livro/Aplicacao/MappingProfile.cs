using AutoMapper;
using LojaServicos.Api.Livro.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaServicos.Api.Livro.Aplicacao
{
    public class MappingProfile : Profile 
    {
        public  MappingProfile()
        {
            CreateMap<LivrariaMaterial, LivrariaMaterialDto>();
        }
    }
}
