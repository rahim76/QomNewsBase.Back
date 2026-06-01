using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Infrastructure.Services;

public class FileSystemStorageService(IWebHostEnvironment webHostEnvironment,
    IConfiguration configuration, ILogger<FileSystemStorageService> _logger) : IFileStorageService
{
    public void DeleteFile(string filePath)
    {
        try
        {
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Not existsting file in '{filePath}'", filePath);
            //throw;
        }
    }

    public async Task<string> UploadThumbnailAsync(Stream fileStream, string originalFileName, string contentType)
    {
        var fileExtension = Path.GetExtension(originalFileName);
        var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
        var filePath = GetThumbnailPath(uniqueFileName);

        try
        {
            using (var file = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(file);
            }

            return uniqueFileName;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading file '{OriginalFileName}'", originalFileName);
            throw;
        }
    }

    public string GetThumbnailPath(string thumbnailName)
    {
        var basePath = Path.Combine(webHostEnvironment.WebRootPath, configuration.GetSection("ThumbnailUploadsFolder").Value!);

        if (!Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }

        return Path.Combine(basePath, thumbnailName);

    }

}