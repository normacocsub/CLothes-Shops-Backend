using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public required string UrlImagen { get; set; }
    [ForeignKey("Categoria")]
    public required int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public required string ProveedorId { get; set; }
}
