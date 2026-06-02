namespace QomNewsBase.Application.Utilities;
public static class PathBuilder
{
    public static string _wwwRootPath { get; private set; } = string.Empty;
    public static string _baseUrl { get; private set; } = string.Empty;
    public static string _thumbnailPath { get; private set; } = string.Empty;
    public static string _adThumbnailPath { get; private set; } = string.Empty;

    public static void Initialize(string wwwRootPath, string baseUrl, string thumbnailUploadsFolder, string adThumbnailPath)
    {
        _baseUrl = baseUrl;
        _thumbnailPath = thumbnailUploadsFolder;
        _adThumbnailPath = adThumbnailPath;
        _wwwRootPath = wwwRootPath;
    }

    public static string GetThumbnailUrl(string fileName)
    {
        var path = GetThumbnailUrl();
        return Path.Combine(path, fileName);

    }

    public static string GetThumbnailUrl()
    {
        var path = Path.Combine(_wwwRootPath, _thumbnailPath);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;

    }

    public static string ShowThumbnailUrl(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return string.Empty;

        if (string.IsNullOrEmpty(_baseUrl))
        {
            throw new ArgumentNullException("Url");
        }

        return $"{_baseUrl}/{_thumbnailPath}/{fileName}";

    }

    public static string GetAdThumbnailUrl(string fileName)
    {
        var path = GetAdThumbnailUrl();
        return Path.Combine(path, fileName);

    }

    public static string GetAdThumbnailUrl()
    {
        var path = Path.Combine(_wwwRootPath, _adThumbnailPath);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        return path;

    }

    public static string ShowAdThumbnailUrl(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            return string.Empty;

        if (string.IsNullOrEmpty(_baseUrl))
        {
            throw new ArgumentNullException("Url");
        }

        return $"{_baseUrl}/{_adThumbnailPath}/{fileName}";

    }


}