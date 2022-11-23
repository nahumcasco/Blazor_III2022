using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Producto
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La existencia es obligatorio")]
        public int Existencia { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime FechaCreacion { get; set; }
        public byte[]? Imagen { get; set; }
    }
}
