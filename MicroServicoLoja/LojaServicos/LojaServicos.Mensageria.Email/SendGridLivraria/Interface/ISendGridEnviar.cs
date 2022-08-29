using LojaServicos.Mensageria.Email.SendGridLivraria.Modelo;
using System.Threading.Tasks;

namespace LojaServicos.Mensageria.Email.SendGridLivraria.Interface
{
    public interface ISendGridEnviar
    {
        Task<(bool resultado, string errorMessage)> EnviarEmail(SendGridData data);
    }
}
