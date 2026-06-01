using AutoMapper;
using MediatR;
using QomNewsBase.Application.Common.Results;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Application.CQRS;
public class CreateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper)
    : IRequestHandler<CreateCommentCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = mapper.Map<Comment>(request);

        await repository.AddAsync(comment, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return Result<bool>.Ok(true);

    }
}