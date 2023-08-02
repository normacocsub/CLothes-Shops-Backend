using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Usuario
{
    [Key]
    public required string Correo { get; set; }
    public required string Cedula { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public required string Genero { get; set; }
    public required string Direccion { get; set; }
    public required string Telefono { get; set; }
    public string? Ciudad { get; set; }
    public required string HashPassword { get; set; }
    [ForeignKey("Rol")]
    public int RolId { get; set; }
    public Rol? Rol { get; set; }
}
