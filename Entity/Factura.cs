using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Factura
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public required List<DetalleFactura> Detalles { get; set; }
    public decimal Total { get; set; }
    public required string Estado { get; set; }
    [ForeignKey("Cliente")]
    public required string IdCliente { get; set; }
    public Usuario? Cliente { get; set; }
}
