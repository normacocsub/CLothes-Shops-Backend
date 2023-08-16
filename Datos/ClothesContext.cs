using Entity;
using Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace Datos;

public class ClothesContext : DbContext, IClothesContext
{
    public ClothesContext(DbContextOptions<ClothesContext> options)
            : base(options)
    {
    }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<DetalleFactura> Detalles { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Proveedor> Proveedors { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    DbSet<Rol> IClothesContext.Roles => Roles;
    DbSet<Categoria> IClothesContext.Categorias => Categorias;
    DbSet<DetalleFactura> IClothesContext.Detalles => Detalles;
    DbSet<Factura> IClothesContext.Facturas => Facturas;
    DbSet<Producto> IClothesContext.Productos => Productos;
    DbSet<Usuario> IClothesContext.Usuarios => Usuarios;
    DbSet<Proveedor> IClothesContext.Proveedors => Proveedors;

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Proveedor>()
                .HasKey(p => p.NIT);

        modelBuilder.Entity<Categoria>().HasData(
            new Categoria() { Codigo = 1, Nombre = "Camisas" },
            new Categoria() { Codigo = 2,  Nombre = "Chaquetas" },
            new Categoria() { Codigo = 3,  Nombre = "Faldas" },
            new Categoria() { Codigo = 4,  Nombre = "Pantalones" },
            new Categoria() { Codigo = 5,  Nombre = "Sudaderas" },
            new Categoria() { Codigo = 6,  Nombre = "Vestidos" }
        );

        modelBuilder.Entity<Rol>().HasData(
            new Rol() { Codigo = 1, Nombre = "Administrador"},
            new Rol() { Codigo = 3, Nombre = "Cliente"}
        );

        modelBuilder.Entity<Usuario>().HasData(
            new Usuario() { 
                Cedula = "",
                Apellido = "",
                Ciudad = "",
                Correo = "admin123@gmail.com",
                Direccion = "",
                HashPassword = Password.GenerateHash("Hola123*"),
                Nombre = "",
                RolId = 1,
                Telefono = ""
            }
           );
    }
}
