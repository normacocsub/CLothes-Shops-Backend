using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Drive.v3.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Infraestructura;



public class GoogleDriveService : IGoogleDriveService
{
    private readonly DriveService service;

    public GoogleDriveService()
    {
        // Configurar las credenciales de la cuenta de servicio
        GoogleCredential credential;
        string directorioProyecto1 = Directory.GetCurrentDirectory();

        string rutaCredenciales = Path.Combine(directorioProyecto1, "credenciales", "credenciales.json");

        using (var stream = new FileStream(rutaCredenciales, FileMode.Open, FileAccess.Read))
            {
            credential = GoogleCredential.FromStream(stream)
                .CreateScoped(DriveService.Scope.Drive);
        }

        // Crear el servicio de Google Drive
        service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Tienda"
        });
    }

    public async Task<string> CargarImagen(Stream imagenStream, string nombreArchivo, string idCarpeta)
    {
        // Cargar el archivo en Google Drive
        var fileMetadata = new Google.Apis.Drive.v3.Data.File()
        {
            Name = nombreArchivo,
            Parents = new List<string> { idCarpeta }
        };

        FilesResource.CreateMediaUpload request = service.Files.Create(fileMetadata, imagenStream, "image/jpeg");
        request.Fields = "id";

        await request.UploadAsync();
        var archivo = await service.Files.Get(request.ResponseBody.Id).ExecuteAsync();
        var idArchivo = archivo.Id;

        if (!string.IsNullOrEmpty(idArchivo))
        {
            return idArchivo;
        }
        else
        {
            throw new Exception($"Error al cargar la imagen en Google Drive.");
        }
    }
}

