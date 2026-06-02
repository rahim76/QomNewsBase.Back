using Microsoft.Extensions.Logging;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Application.Utilities;

namespace QomNewsBase.Infrastructure.Services;

public class FileSystemStorageService(
    ILogger<FileSystemStorageService> _logger) : IFileStorageService
{
    public void DeleteFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                _logger.LogWarning("File not found: '{filePath}'", filePath);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting file '{filePath}'", filePath);
            throw;
        }
    }


    private string GenerateUniqueFileName()
    {
        return Guid.NewGuid().ToString();
    }

    private async Task Upload(string filePath, Stream fileStream, string originalFileName)
    {
        try
        {
            using (var file = new FileStream(filePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(file);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading file '{OriginalFileName}'", originalFileName);
            throw;
        }
    }

    public async Task<string> UploadThumbnailAsync(Stream fileStream, string originalFileName)
    {
        var fileExtension = Path.GetExtension(originalFileName);
        var uniqueFileName = GenerateUniqueFileName() + fileExtension;

        var filePath = GetThumbnailPath(uniqueFileName);

        await Upload(filePath, fileStream, originalFileName);

        return uniqueFileName;
    }

    public async Task<string> UploadAdThumbnailAsync(Stream fileStream, string originalFileName)
    {
        var fileExtension = Path.GetExtension(originalFileName);
        var uniqueFileName = GenerateUniqueFileName() + fileExtension;
        var filePath = GetAdThumbnailPath(uniqueFileName);

        await Upload(filePath, fileStream, originalFileName);

        return uniqueFileName;
    }

    private string GetThumbnailPath(string thumbnailName)
    {
        var basePath = PathBuilder.GetThumbnailUrl();

        if (!Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }

        return Path.Combine(basePath, thumbnailName);

    }

    private string GetAdThumbnailPath(string thumbnailName)
    {
        var basePath = PathBuilder.GetAdThumbnailUrl();

        if (!Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }

        return Path.Combine(basePath, thumbnailName);

    }

}