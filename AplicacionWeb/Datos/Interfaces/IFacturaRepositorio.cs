using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IFacturaRepositorio
    {
        Task<int> Nueva(Factura factura);
    }
}
