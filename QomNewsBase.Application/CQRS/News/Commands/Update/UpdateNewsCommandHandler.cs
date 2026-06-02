using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Application.Utilities;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;

public class UpdateNewsCommandHandler(IRepository<News> repository,
    INewsRepository newsRepository,
    IFileStorageService fileStorageService) : IRequestHandler<UpdateNewsCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetByIdAsync(request.Id, cancellationToken);

        var thumbnailFileName = news!.Thumbnail;

        if (request.Image != null && request.Image.Length > 0)
        {
            #region Save New Thumbnail

            thumbnailFileName = await fileStorageService.UploadThumbnailAsync(request.Image.OpenReadStream(), request.Image.FileName);

            #endregion

            #region Delete Old Thumbnail

            if (!string.IsNullOrEmpty(news.Thumbnail))
            {
                var newsThumbnailPath = PathBuilder.GetThumbnailUrl(news.Thumbnail);

                fileStorageService.DeleteFile(newsThumbnailPath);
            }

            #endregion

        }

        news.Update(request.Title, thumbnailFileName, request.NewsGroupId, request.Description);

        repository.Update(news);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);

    }
}