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
    public class UsuarioTest
    {
        private UsuarioService _usuarioService;
        private Mock<IClothesContext> _contextMock;
        private DbSet<Usuario> _usuarioDbSet;


        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<IClothesContext>();
            _usuarioDbSet = GetMockedDbSet(new List<Usuario>());

            _contextMock.Setup(c => c.Usuarios).Returns(_usuarioDbSet);
            _contextMock.Setup(c => c.Usuarios.Add(It.IsAny<Usuario>())).Verifiable();

            

            _contextMock.Setup(c => c.Usuarios.Update(It.IsAny<Usuario>())).Verifiable();

            _usuarioService = new UsuarioService(_contextMock.Object);
        }

        [Test]
        public void CrearUsuario()
        {
            Usuario usuario = new() 
            { 
                Apellido = "Prueba",
                Cedula = "33445",
                Correo = "Prueba@gmail.com",
                Direccion = "Valledupar",
                HashPassword = "PruebaHash?*",
                Nombre = "Prueba",
                Ciudad = "Valledupar",
                RolId = 2,
                Telefono = "3214567891"
            };

            Usuario response = _usuarioService.CrearUsuario(usuario);

            Assert.That(response, Is.Not.Null);
            Assert.That(response, Is.EqualTo(usuario));

            _contextMock.Verify(c => c.Usuarios.Add(usuario), Times.Once);
            _contextMock.Verify(c => c.SaveChanges(), Times.Once);

        }


        [Test]
        public void DuplicateUsuario()
        {

            Usuario usuario = new()
            {
                Apellido = "Prueba",
                Cedula = "33445",
                Correo = "Prueba@gmail.com",
                Direccion = "Valledupar",
                HashPassword = "PruebaHash?*",
                Nombre = "Prueba",
                Ciudad = "Valledupar",
                RolId = 2,
                Telefono = "3214567891"
            };

            _usuarioDbSet = GetMockedDbSet(new List<Usuario>() { usuario });
            _contextMock.Setup(c => c.Usuarios).Returns(_usuarioDbSet);
            _contextMock.Setup(c => c.Usuarios.Add(It.IsAny<Usuario>())).Verifiable();



            _contextMock.Setup(c => c.Usuarios.Update(It.IsAny<Usuario>())).Verifiable();

            _usuarioService = new UsuarioService(_contextMock.Object);


            Usuario response = _usuarioService.CrearUsuario(usuario);

            Assert.That(response, Is.Null);

            _contextMock.Verify(c => c.Usuarios.Add(usuario), Times.Never);
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
