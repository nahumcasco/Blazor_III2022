namespace Modelos
{
    public class Usuario
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string? Correo { get; set; }
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }
}
