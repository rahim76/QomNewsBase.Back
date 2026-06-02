using AutoMapper;
using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;

public class CreateNewsCommandHandler(IRepository<News> repository,
    IMapper mapper,
    IFileStorageService fileStorageService) : IRequestHandler<CreateNewsCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = mapper.Map<News>(request);

        #region Save Thumbnail

        if (request.Image != null && request.Image.Length > 0)
        {
            news.Thumbnail = await fileStorageService.UploadThumbnailAsync(request.Image.OpenReadStream(), request.Image.FileName);
        }

        #endregion

        await repository.AddAsync(news, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);

        return Result<bool>.Ok(true);
    }
}