using Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClotheShops.Models
{
    public class DetalleFacturaDTO
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public DateTime Fecha { get; set; }
        public  int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
