using Entity;

namespace Logica;

public interface IUsuarioService
{
    Usuario CrearUsuario(Usuario usuario);
    Usuario BuscarUsuario(string cedula);
    Usuario BuscarUsuarioCorreo(string correo);
    Usuario Login(string correo, string password);
    List<Usuario> GetProveedores();
}
