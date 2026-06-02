namespace QomNewsBase.Application.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadThumbnailAsync(Stream fileStream, string fileName);
    Task<string> UploadAdThumbnailAsync(Stream fileStream, string originalFileName);
    void DeleteFile(string filePath);
    //string GetThumbnailPath(string thumbnailName);
    //string GetAdThumbnailPath(string thumbnailName);
}