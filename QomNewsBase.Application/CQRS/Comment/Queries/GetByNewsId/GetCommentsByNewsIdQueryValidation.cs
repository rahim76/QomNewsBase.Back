using FluentValidation;

namespace QomNewsBase.Application.CQRS;

public class GetCommentsByNewsIdQueryValidation : AbstractValidator<GetCommentsByNewsIdQuery>
{
    public GetCommentsByNewsIdQueryValidation()
    {
        RuleFor(a => a.NewsId)
            .NotNull().WithMessage("NewsId con't be null or empty");
    }
}