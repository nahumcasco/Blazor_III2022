using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El Código es Obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Nombre es Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La clave es Obligatorio")]
        public string Clave { get; set; }
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Rol es Obligatorio")]
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}
