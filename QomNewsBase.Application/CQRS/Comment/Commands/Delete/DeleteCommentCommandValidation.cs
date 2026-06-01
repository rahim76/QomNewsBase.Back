using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class DeleteCommentCommandValidation : AbstractValidator<DeleteCommentCommand>
{
    public DeleteCommentCommandValidation(ICommentRepository commentRepository)
    {
        RuleFor(a => a.Id)
            .NotNull().WithMessage("id con't be null.")
            .MustAsync(async (id, cancellationToken) => await commentRepository.Any(id, cancellationToken)
            ).WithMessage("comment not found !");
    }
}