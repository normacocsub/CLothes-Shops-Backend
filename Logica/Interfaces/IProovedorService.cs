using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface IProovedorService
    {
        Proveedor CrearProveedor(Proveedor proveedor);
        List<Proveedor> ConsultarProveedores();
        Proveedor ConsultarProveedor(string proveedorId);
        Proveedor ModificarProveedor(Proveedor proveedor);
        Proveedor EliminarProveedor(string proveedorId);
    }
}
