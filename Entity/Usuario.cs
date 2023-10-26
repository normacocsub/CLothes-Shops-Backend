using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Usuario : Persona
{
    public string Cedula { get; set; }
    public string HashPassword { get; set; }
    [ForeignKey("Rol")]
    public int RolId { get; set; }
    public Rol? Rol { get; set; }
}
