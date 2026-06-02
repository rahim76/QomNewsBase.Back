using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Application.Utilities;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;
public class DeleteAdCommandHandler(IRepository<Ad> repository, IFileStorageService fileStorageService) : IRequestHandler<DeleteAdCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
    {
        var ad = await repository.GetByIdAsync(request.Id, cancellationToken);

        #region Delete Thumbnail

        if (!string.IsNullOrEmpty(ad!.Thumbnail))
        {
            var newsThumbnailPath = PathBuilder.GetAdThumbnailUrl(ad.Thumbnail);

            fileStorageService.DeleteFile(newsThumbnailPath);
        }

        #endregion

        repository.Delete(ad);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);
    }
}