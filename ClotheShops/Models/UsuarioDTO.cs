using Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClotheShops.Models
{
    public class UsuarioDTO
    {
        public  string Correo { get; set; }
        public  string Cedula { get; set; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  string Direccion { get; set; }
        public  string Telefono { get; set; }
        public string? Ciudad { get; set; }
        public  string Password { get; set; }
        public int RolId { get; set; }
    }

    public class ProveedorDTO
    {
        public  string Correo { get; set; }
        public  string Cedula { get; set; }
        public  string Nombre { get; set; }
        public  string Apellido { get; set; }
        public  string Direccion { get; set; }
        public  string Telefono { get; set; }
        public string? Ciudad { get; set; }
        public  string Nit { get; set; }
    }
}
