using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        [Key]
        public required string Correo { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Ciudad { get; set; }
    }
}
