using Datos;
using Entity;
using Logica;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestProject1
{
    [TestFixture]
    public class ProveedorTest
    {
        private ProveedorService _proveedorService;
        private Mock<IClothesContext> _contextMock;
        private DbSet<Proveedor> _proveedoresDbSet;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<IClothesContext>();
            _proveedoresDbSet = GetMockedDbSet(new List<Proveedor>());

            _contextMock.Setup(c => c.Proveedors).Returns(_proveedoresDbSet);
            _contextMock.Setup(c => c.Proveedors.Add(It.IsAny<Proveedor>())).Verifiable();
            _contextMock.Setup(c => c.Proveedors.Update(It.IsAny<Proveedor>())).Verifiable();
            _proveedorService = new ProveedorService(_contextMock.Object);
        }

        [Test]
        public void GuardarProveedor()
        {
            Proveedor proveedor = new() {
                Apellido = "Prueba",
                Ciudad = "Valledupar",
                Correo = "Prueba@gmail.com",
                Direccion = "Valledupar",
                NIT = "5454-R",
                Nombre = "Adriana",
                Telefono = "3210345678"
            };
            
            Proveedor result = _proveedorService.CrearProveedor(proveedor);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(proveedor));

            _contextMock.Verify(c => c.Proveedors.Add(proveedor), Times.Once);
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);

        }

        [Test]
        public void DuplicarProveedor()
        {
            Proveedor proveedor = new()
            {
                Apellido = "Prueba",
                Ciudad = "Valledupar",
                Correo = "Prueba@gmail.com",
                Direccion = "Valledupar",
                NIT = "5454-R",
                Nombre = "Adriana",
                Telefono = "3210345678"
            };

            _proveedoresDbSet = GetMockedDbSet(new List<Proveedor>() { proveedor });

            _contextMock.Setup(c => c.Proveedors).Returns(_proveedoresDbSet);
            _contextMock.Setup(c => c.Proveedors.Add(It.IsAny<Proveedor>())).Verifiable();
            _contextMock.Setup(c => c.Proveedors.Update(It.IsAny<Proveedor>())).Verifiable();
            _proveedorService = new ProveedorService(_contextMock.Object);

            Proveedor result = _proveedorService.CrearProveedor(proveedor);

            Assert.That(result, Is.Null);

            _contextMock.Verify(c => c.Proveedors.Add(proveedor), Times.Never);
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