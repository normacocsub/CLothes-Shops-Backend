using Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClotheShops.Models
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public required List<DetalleFacturaDTO> Detalles { get; set; }
        public decimal Total { get; set; }
        public required string Estado { get; set; }
        public required string IdCliente { get; set; }
        public Usuario Cliente { get; set; }
    }
}
