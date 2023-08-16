using Entity;

namespace Logica;

public interface IProductoService
{
    Task<Producto> GuardarProducto(Stream imagenStream, Producto producto);
    List<Producto> ConsultarProductos();
    Producto ConsultarProducto(int id);
}
