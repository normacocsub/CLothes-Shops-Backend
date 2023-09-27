using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica;

public class FacturaService : IFacturaService
{
    private readonly IClothesContext _context;
    public FacturaService(IClothesContext context)
    {
        _context = context;
    }

    public Factura CrearFactura(Factura factura)
    {
        try
        {
            if (factura is null || factura.Cliente is null || _context is null) return null;
            Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == factura.Cliente.Correo);
            if (usuario is null) return null;
            factura.IdCliente = usuario.Cedula;
            factura.Cliente = usuario;
            _context.Facturas.Add(factura);
            factura.Detalles.ForEach((item) =>
            {
                Producto producto = _context.Productos.Find(item.Producto.Codigo);
                if (producto is null) return;
                item.Producto = producto;
                producto.Stock -= item.Cantidad;
                _context.Productos.Update(producto);
            });
            _context.SaveChanges();
            return factura;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<Factura> GetFacturaList(string correo)
    {
        try
        {
            return _context.Facturas
                .Include(factura => factura.Detalles)
                    .ThenInclude(detalle => detalle.Producto)
                        .Include(factura => factura.Cliente)
                            .Where(factura => factura.Cliente.Correo == correo)
                                .ToList();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Factura GetFactura(int facturaId)
    {
        try
        {
            return _context.Facturas
                .Include(factura => factura.Detalles)
                .ThenInclude(detalle => detalle.Producto)
                .Include(factura => factura.Cliente)
                .FirstOrDefault(factura => factura.Id == facturaId);
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
