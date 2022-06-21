using Microsoft.Net.Http.Headers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Domain.Common;
using PromotionSales.Api.WebUI.Helpers;

namespace PromotionSales.Api.WebUI.Services;

public class BlobStorageGateway : IBlobStorageGateway
{
    private CloudBlobContainer container;
    private readonly AppSettings _appSettings;

    public BlobStorageGateway(AppSettings appSettings)
    {
        _appSettings = appSettings;

        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_appSettings.Blob.ConnectionString);

        // Create the blob client.
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

        // Retrieve a reference to a container.
        container = blobClient.GetContainerReference(_appSettings.Blob.ContainerReference);

        // Create the container if it doesn't already exist.
        container.CreateIfNotExists();

        container.SetPermissionsAsync(new BlobContainerPermissions
        {
            PublicAccess = BlobContainerPublicAccessType.Off
        });
    }

    public List<string> GetUrls(string prefix = null)
    {
        prefix = Prefix(prefix);

        var urls = new List<string>();

        foreach (IListBlobItem item in container.ListBlobs(prefix, true))
        {
            if (item.GetType() == typeof(CloudBlockBlob))
            {
                CloudBlockBlob blob = (CloudBlockBlob)item;

                if (!blob.Uri.ToString().Contains(".eliminado"))
                {
                    urls.Add(blob.Uri.ToString());
                }
            }
            else if (item.GetType() == typeof(CloudPageBlob))
            {
                CloudPageBlob pageBlob = (CloudPageBlob)item;

                urls.Add(pageBlob.Uri.ToString());
            }
            else if (item.GetType() == typeof(CloudBlobDirectory))
            {
                CloudBlobDirectory directory = (CloudBlobDirectory)item;
            }
        }

        return urls;
    }

    public async Task<string> UploadFile(IFormFile file, string prefix = null, bool actualizar = false, bool agregarSeparadorGUID = false)
    {
        prefix = Prefix(prefix);

        if (actualizar)
        {
            List<string> archivos = GetUrls(prefix);

            foreach (string archivo in archivos)
            {
                this.DeleteBlob(archivo.Substring(archivo.IndexOf(prefix)));
            }
        }

        var fileName = Guid.NewGuid().ToString() + (agregarSeparadorGUID ? "_" : "") + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');

        if (prefix != null)
        {
            fileName = prefix + fileName;
        }

        var blob = container.GetBlockBlobReference(fileName);

        using (var stream = file.OpenReadStream())
        {
            byte[] fileBytes = new byte[stream.Length];
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            await blob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length);
        }

        return _appSettings.Blob.BaseUrl + fileName;
    }

    public void DeleteBlobs(string prefix = null)
    {
        prefix = Prefix(prefix);

        var dierctorio = container.GetDirectoryReference(prefix);
        var archivos = dierctorio.ListBlobs(true);

        foreach (var archivo in archivos)
        {
            CloudBlockBlob blob = (CloudBlockBlob)archivo;
            CloudBlockBlob blobCopy = container.GetBlockBlobReference(blob.Name + ".eliminado");
            blobCopy.StartCopy(blob);
            blob.Delete();
        }
    }

    public void DeleteBlob(string prefix = null)
    {
        prefix = Prefix(prefix);

        CloudBlockBlob blobCopy = container.GetBlockBlobReference(prefix + ".eliminado");

        foreach (IListBlobItem item in container.ListBlobs(prefix, true))
        {
            if (item.GetType() == typeof(CloudBlockBlob))
            {
                CloudBlockBlob blob = (CloudBlockBlob)item;
                blobCopy.StartCopy(blob);
                blob.Delete();
            }
        }
    }

    /// <summary>
    /// Copia todos los archivos de la carpeta origen a la carpeta destino.
    /// </summary>
    /// <param name="pathOrigen">Path de la carpeta a copiar.</param>
    /// <param name="pathDestino">Path de la carpeta destino.</param>
    public void CopyBlobs(string pathOrigen, string pathDestino)
    {
        pathOrigen = Prefix(pathOrigen);
        pathDestino = Prefix(pathDestino);

        foreach (IListBlobItem item in container.ListBlobs(pathOrigen, false))
        {
            if (item.GetType() == typeof(CloudBlockBlob))
            {
                CloudBlockBlob blob = (CloudBlockBlob)item;

                // Se cambia blob.Uri.AbsolutePath por blob.Name porque el primero cambia caracteres especiales por encode mientras que Name es el nombre original
                CloudBlockBlob blobCopy = container.GetBlockBlobReference(pathDestino + Path.GetFileName(blob.Name));
                blobCopy.StartCopy(blob);
            }
        }
    }

    private string Prefix(string prefix)
    {
        return $"{(_appSettings.Blob.Desarrollo ? "desarrollo/" : "")}{prefix ?? ""}";
    }

    public List<ImagenBase64> GetBase64(string prefix = null)
    {
        prefix = Prefix(prefix);

        var urls = new List<ImagenBase64>();

        foreach (IListBlobItem item in container.ListBlobs(prefix, true))
        {
            if (item.GetType() == typeof(CloudBlockBlob))
            {
                CloudBlockBlob blob = (CloudBlockBlob)item;

                if (!blob.Uri.ToString().Contains(".eliminado"))
                {
                    blob.FetchAttributes();
                    long fileByteLength = blob.Properties.Length;
                    byte[] fileContent = new byte[fileByteLength];
                    for (int i = 0; i < fileByteLength; i++)
                    {
                        fileContent[i] = 0x20;
                    }

                    blob.DownloadToByteArray(fileContent, 0);
                    string base64String = Convert.ToBase64String(fileContent, 0, fileContent.Length);
                    urls.Add(new ImagenBase64
                    {
                        Nombre = blob.Uri.ToString().Split('/').Last(),
                        Imagen = "data:application/octet-stream;base64," + base64String
                    });
                }
            }
            else if (item.GetType() == typeof(CloudPageBlob))
            {
                CloudPageBlob pageBlob = (CloudPageBlob)item;

                pageBlob.FetchAttributes();
                long fileByteLength = pageBlob.Properties.Length;
                byte[] fileContent = new byte[fileByteLength];
                for (int i = 0; i < fileByteLength; i++)
                {
                    fileContent[i] = 0x20;
                }

                pageBlob.DownloadToByteArray(fileContent, 0);
                string base64String = Convert.ToBase64String(fileContent, 0, fileContent.Length);
                urls.Add(new ImagenBase64
                {
                    Nombre = pageBlob.Uri.ToString().Split('/').Last(),
                    Imagen = "data:application/octet-stream;base64," + base64String
                });
            }
            else if (item.GetType() == typeof(CloudBlobDirectory))
            {
                CloudBlobDirectory directory = (CloudBlobDirectory)item;
            }
        }

        return urls;
    }
}
