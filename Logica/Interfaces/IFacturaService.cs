using Entity;

namespace Logica;

public interface IFacturaService
{
    Factura CrearFactura(Factura factura);
    List<Factura> GetFacturaList(string correo);
    Factura GetFactura(int idFactura);
}
