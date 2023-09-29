using Datos;
using Entity;
using Infraestructura;
using Logica;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestFixture]
    public class ProductoTest
    {
        private ProductoService _productoService;
        private Mock<IClothesContext> _contextMock;
        private Mock<IGoogleDriveService> _googleDriveServiceMock;
        private DbSet<Producto> _productoDbSet;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<IClothesContext>();
            _productoDbSet = GetMockedDbSet(new List<Producto>());

            _contextMock.Setup(c => c.Productos).Returns(_productoDbSet);
            _contextMock.Setup(c => c.Productos.Add(It.IsAny<Producto>())).Verifiable();
            _contextMock.Setup(c => c.Productos.Update(It.IsAny<Producto>())).Verifiable();

            _googleDriveServiceMock = new Mock<IGoogleDriveService>();
            _productoService = new ProductoService(_contextMock.Object);

        }

        [Test]
        public async Task CrearProducto()
        {
            var imagenStream = new MemoryStream();
            Producto producto = new()
            {
                CategoriaId = 1,
                Descripcion = "Prueba",
                Nombre = "Prueba", 
                ProveedorId = "123",
                UrlImagen = "",
                Precio = 123444,
                Stock = 14
            };

            _googleDriveServiceMock.Setup(d => d.CargarImagen(imagenStream, producto.Nombre, It.IsAny<string>()))
                          .ReturnsAsync("URL de imagen simulada");

            var resultado = await _productoService.GuardarProducto(imagenStream, producto, _googleDriveServiceMock.Object);

            Assert.That(resultado, Is.Not.Null);
            Assert.That(resultado, Is.EqualTo(producto));

            _contextMock.Verify(c => c.Productos.AddAsync(It.IsAny<Producto>(), CancellationToken.None), Times.Once);
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);

        }


        [Test]
        public async Task DuplicarProducto()
        {
            var imagenStream = new MemoryStream();
            Producto producto = new()
            {
                CategoriaId = 1,
                Descripcion = "Prueba",
                Nombre = "Prueba",
                ProveedorId = "123",
                UrlImagen = "",
                Precio = 123444,
                Stock = 14,
                Codigo = 1
            };

            _productoDbSet = GetMockedDbSet(new List<Producto>() { producto } );

            _contextMock.Setup(c => c.Productos).Returns(_productoDbSet);
            _contextMock.Setup(c => c.Productos.Add(It.IsAny<Producto>())).Verifiable();
            _contextMock.Setup(c => c.Productos.Update(It.IsAny<Producto>())).Verifiable();

            _googleDriveServiceMock = new Mock<IGoogleDriveService>();
            _productoService = new ProductoService(_contextMock.Object);


            _googleDriveServiceMock.Setup(d => d.CargarImagen(imagenStream, producto.Nombre, It.IsAny<string>()))
                          .ReturnsAsync("URL de imagen simulada");

            var resultado = await _productoService.GuardarProducto(imagenStream, producto, _googleDriveServiceMock.Object);

            Assert.That(resultado, Is.Null);

            _contextMock.Verify(c => c.Productos.AddAsync(It.IsAny<Producto>(), CancellationToken.None), Times.Never);
            _contextMock.Verify(c => c.SaveChanges(), Times.Never);

        }


        private DbSet<T> GetMockedDbSet<T>(List<T> data) where T : class
        {
            var queryableData = data.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator);

            dbSetMock.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(data.Add);
            dbSetMock.Setup(m => m.Update(It.IsAny<T>())).Callback<T>(item =>
            {
                int index = data.FindIndex(i => i == item);
                data[index] = item;
            });

            return dbSetMock.Object;
        }
    }
}
