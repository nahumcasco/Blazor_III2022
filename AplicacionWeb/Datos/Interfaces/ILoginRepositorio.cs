using Modelos;

namespace Datos.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<bool> ValidarUsuario(Login login);
    }
}
