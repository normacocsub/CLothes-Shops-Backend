using ClotheShops.Models;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace ClotheShops.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        private readonly IFacturaService _service;
        public FacturaController(IFacturaService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Factura> CrearFactura(FacturaDTO input)
        {
            Factura factura = Mapear(input);
            var response = _service.CrearFactura(factura);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(factura);
        }

        [HttpGet]
        public ActionResult<Factura> ConsultarFactura([FromQuery] string correo)
        {
            var response = _service.GetFacturaList(correo);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet("buscar")]
        public ActionResult<Factura> BuscarFactura([FromQuery] string id)
        {
            var response = _service.GetFactura(int.Parse(id));
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        private Factura Mapear(FacturaDTO input)
        {
            Usuario usuario = new Usuario()
            {
                Correo = input.Cliente.Correo,
                Apellido = "",
                Cedula = "",
                Ciudad = "",
                Direccion = "",
                HashPassword = "",
                Nombre = "",
                RolId = 0,
                Telefono = ""
            };
            List<DetalleFactura> detalles = new List<DetalleFactura>();
            foreach (var item in input.Detalles)
            {
                Producto producto = new Producto()
                {
                    Codigo = item.Producto.Codigo,
                    Nombre = item.Producto.Nombre,
                    Descripcion = item.Producto.Descripcion,
                    Stock = item.Producto.Stock,
                    Precio = item.Producto.Precio,
                    CategoriaId = item.Producto.CategoriaId,
                    UrlImagen = item.Producto.UrlImagen,
                    ProveedorId = item.Producto.ProveedorId,
                };
                detalles.Add(new DetalleFactura()
                {
                    Fecha = item.Fecha,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.PrecioUnitario,
                    Producto = producto,
                    ProductoId = producto.Codigo,
                });
            }

            return new Factura()
            {
                Fecha = input.Fecha,
                Total = input.Total,
                Cliente = usuario,
                Detalles = detalles,
                Estado = "Activo",
                IdCliente = input.IdCliente,
            };
        }
    }
}
