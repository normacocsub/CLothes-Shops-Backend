using Datos;
using Entity;
using Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace Logica;

public class ProductoService : IProductoService
{
    private readonly IClothesContext _context;
    public ProductoService(IClothesContext context)
    {
        _context = context;
    }

    public async Task<Producto> GuardarProducto(Stream imagenStream, Producto producto, IGoogleDriveService driveService) {
        try
        {
            var productoResponse = _context.Productos.Where(usu => usu.Codigo ==  producto.Codigo).FirstOrDefault();
            if (productoResponse is not null) return null;


            var response = await driveService.CargarImagen(imagenStream, producto.Nombre, "18mJ4wGZdEGOR72GtjpVpLB4SqQ3xXBVK");
            producto.UrlImagen = response;
            await _context.Productos.AddAsync(producto);
            _context.SaveChanges();
            return producto;
        } catch (Exception ex)
        {
            return null;
        }
    }


    public List<Producto> ConsultarProductos()
    {
        try
        {
            return _context.Productos.ToList();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    

    public Producto ConsultarProducto(int id)
    {
        try
        {
            return _context.Productos.Find(id);
        } catch (Exception ex)
        {
            return null;
        }
    }
}
