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

    public async Task<Producto> GuardarProducto(Stream imagenStream, Producto producto) {
        try
        {
            GoogleDriveService driveService = new();
            var response = await driveService.CargarImagen(imagenStream, producto.Nombre, "1y6uv8iyumMn8OXOUi456J8FXt8P_s3J6");
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

    public List<Producto> ConsultarProductosProveedores(string correo)
    {
        try
        {
            return _context.Productos.Include(producto => producto.Usuario).Where( producto => producto.Usuario.Correo == correo ).ToList();
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
