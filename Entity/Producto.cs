using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Producto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public string UrlImagen { get; set; }
    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public string ProveedorId { get; set; }
}
