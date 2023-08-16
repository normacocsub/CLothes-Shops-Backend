using Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClotheShops.Models
{
    public class UsuarioDTO
    {
        public required string Correo { get; set; }
        public required string Cedula { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public string? Ciudad { get; set; }
        public required string Password { get; set; }
        public int RolId { get; set; }
    }

    public class ProveedorDTO
    {
        public required string Correo { get; set; }
        public required string Cedula { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public string? Ciudad { get; set; }
        public required string Nit { get; set; }
    }
}
