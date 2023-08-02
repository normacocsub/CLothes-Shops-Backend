using Entity;

namespace Logica;

public interface IProductoService
{
    Task<Producto> GuardarProducto(Stream imagenStream, Producto producto);
    List<Producto> ConsultarProductos();
    List<Producto> ConsultarProductosProveedores(string correo);
    Producto ConsultarProducto(int id);
}
