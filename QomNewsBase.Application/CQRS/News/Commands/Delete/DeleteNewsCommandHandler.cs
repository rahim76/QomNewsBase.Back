using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;

public class DeleteNewsCommandHandler(IRepository<News> repository,
    IFileStorageService fileStorageService) : IRequestHandler<DeleteNewsCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await repository.GetByIdAsync(request.Id, cancellationToken);

        repository.Delete(news!);
        await repository.SaveChangesAsync(cancellationToken);

        #region Delete Thumbnail

        if (!string.IsNullOrEmpty(news!.Thumbnail))
        {
            var newsThumbnailPath = fileStorageService.GetThumbnailPath(news.Thumbnail);

            fileStorageService.DeleteFile(newsThumbnailPath);
        }

        #endregion

        return Result<bool>.Ok(true);

    }
}