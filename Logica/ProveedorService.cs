using Datos;
using Entity;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ProveedorService : IProovedorService
    {
        private readonly IClothesContext _context;
        public ProveedorService(IClothesContext context)
        {
            _context = context;
        }
        public Proveedor ConsultarProveedor(string proveedorId)
        {
            try
            {
                return _context.Proveedors.Find(proveedorId);
            }
            catch (Exception ex) { return null; }
        }

        public List<Proveedor> ConsultarProveedores()
        {
            try
            {
                return _context.Proveedors.ToList();
            }
            catch (Exception e) { return null; }
        }

        public Proveedor CrearProveedor(Proveedor proveedor)
        {
            try
            {
                var proveedorResponse = _context.Proveedors.FirstOrDefault(p => p.NIT == proveedor.NIT);
                if (proveedorResponse is not null) return null;
                _context.Proveedors.Add(proveedor);
                _context.SaveChanges();
                return proveedor;
            }
            catch (Exception e) { return null; }
        }

        public Proveedor EliminarProveedor(string proveedorId)
        {
            try
            {
                Proveedor proveedor = _context.Proveedors.Find(proveedorId);
                if (proveedor is null) { return null; }
                _context.Proveedors.Remove(proveedor);
                _context.SaveChanges();
                return proveedor;
            }
            catch (Exception e) { return null; }
        }

        public Proveedor ModificarProveedor(Proveedor proveedor)
        {
            throw new NotImplementedException();
        }
    }
}
