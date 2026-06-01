using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class CreateCommentCommandValidation : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidation(INewsRepository newsRepository)
    {
        RuleFor(x => x.NewsId)
             .NotEmpty()
             .MustAsync(newsRepository.Any)
             .WithMessage("The specified newsGroup item does not exist.");

        RuleFor(x => x.CommentBody)
            .NotNull().WithMessage("Body Can't be null !")
            .NotEmpty().WithMessage("Body Can't be Empty");
    }
}