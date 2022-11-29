using Modelos;

namespace Blazor.Interfaces
{
    public interface IFacturaServicio
    {
        Task<int> Nueva(Factura factura);
    }
}
