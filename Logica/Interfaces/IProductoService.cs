using Entity;
using Infraestructura;

namespace Logica;

public interface IProductoService
{
    Task<Producto> GuardarProducto(Stream imagenStream, Producto producto, IGoogleDriveService driveService);
    List<Producto> ConsultarProductos();
    Producto ConsultarProducto(int id);
}
