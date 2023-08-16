using ClotheShops.Models;
using Entity;
using Logica.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClotheShops.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProovedorService _service;
        public ProveedorController(IProovedorService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ProveedorDTO> RegistrarProveedor(ProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = MapearProveedor(proveedorDTO);
            var response = _service.CrearProveedor(proveedor);
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<List<ProveedorDTO>> ConsultarProveedores()
        {
            var response = _service.ConsultarProveedores();
            if (response is null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        private Proveedor MapearProveedor(ProveedorDTO proveedorDTO)
        {
            return new Proveedor()
            {
                Apellido = proveedorDTO.Apellido,
                Ciudad = proveedorDTO.Ciudad,
                Correo = proveedorDTO.Correo,
                Direccion = proveedorDTO.Direccion,
                NIT = proveedorDTO.Nit,
                Nombre = proveedorDTO.Nombre,
                Telefono = proveedorDTO.Telefono
            };
        }
    }
}
