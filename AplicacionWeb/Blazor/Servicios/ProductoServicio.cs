using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly Config _configuracion;
        private IProductoRepositorio productoRepositorio;

        public ProductoServicio(Config config)
        {
            _configuracion = config;
            productoRepositorio = new ProductoRepositorio(config.CadenaConexion);
        }

        public async Task<bool> Actualizar(Producto producto)
        {
            return await productoRepositorio.Actualizar(producto);
        }

        public async Task<bool> Eliminar(int codigo)
        {
            return await productoRepositorio.Eliminar(codigo);
        }

        public async Task<IEnumerable<Producto>> GetLista()
        {
            return await productoRepositorio.GetLista();
        }

        public async Task<Producto> GetPorCodigo(int codigo)
        {
            return await productoRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Producto producto)
        {
            return await productoRepositorio.Nuevo(producto);
        }
    }
}
