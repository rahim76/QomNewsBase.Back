namespace QomNewsBase.Application.Utilities;
public static class PathBuilder
{
    public static string _baseUrl { get; private set; } = string.Empty;
    public static string _thumbnailPath { get; private set; } = string.Empty;

    public static void Initialize(string baseUrl, string thumbnailUploadsFolder)
    {
        _baseUrl = baseUrl;
        _thumbnailPath = thumbnailUploadsFolder;
    }

    public static string GetThumbnailUrl(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return string.Empty;

        if (string.IsNullOrEmpty(_baseUrl))
        {
            throw new ArgumentNullException("Url");
        }

        return $"{_baseUrl}/{_thumbnailPath}/{fileName}";

    }
}