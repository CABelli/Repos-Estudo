using LojaServicos.Api.CarrinhoCompra.RemoteModel;
using System;
using System.Threading.Tasks;

namespace LojaServicos.Api.CarrinhoCompra.RemoteInterface
{
    public interface ILivroService
    {
        Task<(bool resultado, LivroRemote Livro, string ErrorMessage)> GetLivro(Guid LivroId);
    }
}
