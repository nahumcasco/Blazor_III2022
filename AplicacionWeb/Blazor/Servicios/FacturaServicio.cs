using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Blazor.Servicios
{
    public class FacturaServicio : IFacturaServicio
    {
        private readonly Config _configuracion;
        private IFacturaRepositorio facturaRepositorio;

        public FacturaServicio(Config config)
        {
            _configuracion = config;
            facturaRepositorio = new FacturaRepositorio(config.CadenaConexion);
        }

        public async Task<int> Nueva(Factura factura)
        {
            return await facturaRepositorio.Nueva(factura);
        }
    }
}
