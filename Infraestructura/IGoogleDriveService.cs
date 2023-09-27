using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public interface IGoogleDriveService
    {
        Task<string> CargarImagen(Stream imagenStream, string nombre, string carpetaId);
    }
}
