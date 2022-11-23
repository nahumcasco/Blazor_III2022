using Modelos;

namespace Blazor.Interfaces
{
    public interface IProductoServicio
    {
        Task<bool> Nuevo(Producto producto);
        Task<bool> Actualizar(Producto producto);
        Task<bool> Eliminar(int codigo);
        Task<IEnumerable<Producto>> GetLista();
        Task<Producto> GetPorCodigo(int codigo);
    }
}
