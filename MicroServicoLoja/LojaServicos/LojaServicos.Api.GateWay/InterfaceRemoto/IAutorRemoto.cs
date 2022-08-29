using LojaServicos.Api.GateWay.LivroRemoto;
using System;
using System.Threading.Tasks;

namespace LojaServicos.Api.GateWay.InterfaceRemoto
{
    public interface IAutorRemoto
    {
        Task<(bool resultado, AutorModeloRemoto autor, string ErrorMessage)> GetAutor(Guid AutorId);
    }
}
