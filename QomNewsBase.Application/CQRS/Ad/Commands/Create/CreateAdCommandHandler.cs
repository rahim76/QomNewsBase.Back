using AutoMapper;
using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;

public class CreateAdCommandHandler(IRepository<Ad> repository, IMapper mapper, IFileStorageService fileStorageService) : IRequestHandler<CreateAdCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateAdCommand request, CancellationToken cancellationToken)
    {
        var ad = mapper.Map<Ad>(request);

        #region Save Thumbnail

        if (request.Thumbnail != null && request.Thumbnail.Length > 0)
        {
            await fileStorageService.UploadAdThumbnailAsync(request.Thumbnail.OpenReadStream(), request.Thumbnail.FileName);
        }

        #endregion

        await repository.AddAsync(ad, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);

    }
}
