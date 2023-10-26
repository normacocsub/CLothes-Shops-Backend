using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class DetalleFactura
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public DateTime Fecha { get; set; }
    [ForeignKey("Producto")]
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
}
