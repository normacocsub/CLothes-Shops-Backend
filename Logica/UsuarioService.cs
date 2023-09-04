using Datos;
using Entity;
using Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace Logica;

public class UsuarioService : IUsuarioService
{
    private readonly IClothesContext _context;
    public UsuarioService(IClothesContext context)
    {
        _context = context;
    }
    public Usuario CrearUsuario(Usuario usuario)
    {
        try
        {
            var usuarioResponse = _context.Usuarios.Where( usu => usu.Cedula == usuario.Cedula || usu.Correo == usuario.Correo).FirstOrDefault();
            if (usuarioResponse is not null) return null;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Usuario BuscarUsuario(string cedula)
    {
        try
        {
            var usuarioResponse = _context.Usuarios.Find(cedula);
            if (usuarioResponse is null) return null;
            return usuarioResponse;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<Usuario> GetProveedores()
    {
        try
        {
            return _context.Usuarios.Where(user => user.RolId == 2 ).ToList() ;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Usuario BuscarUsuarioCorreo(string correo)
    {
        try
        {
            var usuarioResponse = _context.Usuarios.Where((usuario) => usuario.Correo == correo).FirstOrDefault();
            if (usuarioResponse is null) return null;
            return usuarioResponse;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Usuario Login(string correo, string password)
    {
        try
        {
            var usuarioResponse = _context.Usuarios.Where((usuario) => usuario.Correo == correo).FirstOrDefault();
            if (usuarioResponse is null) return null;
            var math = Password.VerifyPassword(password, usuarioResponse.HashPassword);
            if (!math) return null;
            usuarioResponse.HashPassword = "";
            return usuarioResponse;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
