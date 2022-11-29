using Modelos;

namespace Blazor.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        Task<bool> Nuevo(DetalleFactura detalleFactura);
    }
}
