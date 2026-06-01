namespace QomNewsBase.Application.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadThumbnailAsync(Stream fileStream, string fileName, string contentType);
    void DeleteFile(string filePath);
    string GetThumbnailPath(string thumbnailName);

}