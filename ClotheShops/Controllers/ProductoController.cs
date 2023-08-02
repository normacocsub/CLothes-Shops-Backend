using ClotheShops.Models;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;

namespace ClotheShops.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _producto;
    public ProductoController(IProductoService producto)
    {
        _producto = producto;
    }

    [HttpPost]
    public async Task<IActionResult> CrearProducto([FromForm] ProductoDto productoDto)
    {

        Producto producto = Mapear(productoDto);

        if (productoDto.Foto != null && productoDto.Foto.Length > 0)
        {
            using var memoryStream = new MemoryStream();
            await productoDto.Foto.CopyToAsync(memoryStream);

            var response = await _producto.GuardarProducto(memoryStream, producto);
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpGet]
    public ActionResult<List<Producto>> ConsultarProductos()
    {
        var response = _producto.ConsultarProductos();
        if (response != null)
        {
            return Ok(response);
        }
        return BadRequest();
    }
    [HttpGet("Proveedores")]
    public ActionResult<List<Producto>> ConsultarProductosProveedor ([FromQuery] string correo)
    {
        var response = _producto.ConsultarProductosProveedores(correo);
        if (response is null)
        {
            return BadRequest();
        }
        return Ok(response);
    }

    [HttpGet("Buscar")]
    public ActionResult<Producto> ConsultarProducto([FromQuery] string codigo)
    {
        var response = _producto.ConsultarProducto(int.Parse(codigo));
        if (response is null)
        {
            return BadRequest();
        }
        return Ok(response);
    }

    private static Producto Mapear(ProductoDto productoDto)
    {
        return new Producto() 
        {
            Nombre = productoDto.Nombre,
            Descripcion = productoDto.Descripcion,
            CategoriaId = productoDto.CategoriaId,
            Stock = productoDto.Stock,
            Precio = productoDto.Precio,
            UrlImagen = "",
            UsuarioId = productoDto.UsuarioId
        };
    }
}
