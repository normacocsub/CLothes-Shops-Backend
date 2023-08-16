using ClotheShops.Models;
using Entity;
using Infraestructura;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace ClotheShops.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Usuario> CrearUsuario(UsuarioDTO input)
        {
            Usuario usuario = Mapear(input);
            usuario.HashPassword = Password.GenerateHash(input.Password);
            var response = _service.CrearUsuario(usuario);
            if (response is null) return BadRequest();
            return Ok(response);
        }
        [HttpGet("buscar")]
        public ActionResult<Usuario> BuscarUsuario([FromQuery] string correo)
        {
            var response = _service.BuscarUsuarioCorreo(correo);
            if (response is null) return BadRequest();
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<Usuario> GetProveedores()
        {
            var response = _service.GetProveedores();
            if (response is null) return BadRequest();
            return Ok(response);
        }

        [HttpPost("Login")]
        public ActionResult<Usuario> IniciarSesion(UsuarioDTO input)
        {
            Usuario usuario = Mapear(input);
            var response = _service.Login(usuario.Correo, usuario.HashPassword);
            if (response is null) return BadRequest();
            return Ok(response);
        }

        private Usuario Mapear(UsuarioDTO input)
        {
            return new Usuario()
            {
                Cedula = input.Cedula,
                Nombre = input.Nombre,
                Apellido = input.Apellido,
                Direccion = input.Direccion,
                Correo = input.Correo,
                HashPassword = input.Password,
                RolId = input.RolId,
                Telefono = input.Telefono,  
                Ciudad = input.Ciudad
            };
        }
    }
}
