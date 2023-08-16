using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos;

public interface IClothesContext
{
    public DbSet<Categoria> Categorias { get; }
    public DbSet<DetalleFactura> Detalles { get; }
    public DbSet<Factura> Facturas { get; }
    public DbSet<Producto> Productos { get; }
    public DbSet<Rol> Roles { get; }
    public DbSet<Usuario> Usuarios { get; }
    public DbSet<Proveedor> Proveedors { get; }
    int SaveChanges();
}
