using AutoMapper;
using LojaServicos.Api.Autor.Modelo;

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
