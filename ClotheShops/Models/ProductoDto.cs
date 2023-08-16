namespace ClotheShops.Models;

public class ProductoDto
{
    public string Nombre { get; set; }
    public int Stock { get; set; }
    public int CategoriaId { get; set; }
    public decimal Precio { get; set; }
    public string Descripcion { get; set; }
    public IFormFile Foto { get; set; }
    public string ProveedorId { get; set; }
}
