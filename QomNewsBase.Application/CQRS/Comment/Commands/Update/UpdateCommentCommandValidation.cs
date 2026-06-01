using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class UpdateCommentCommandValidation : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidation(ICommentRepository commentRepository)
    {
        RuleFor(a => a.Id)
            .NotNull().WithMessage("id can't be null")
            .MustAsync(async (id, cancellationToken) => await commentRepository.Any(id, cancellationToken)).WithMessage("comment not found");

        RuleFor(a => a.CommentBody)
            .NotNull().WithMessage("CommentBody can't be null")
            .NotEmpty().WithMessage("CommentBody can't be empty");

    }
}