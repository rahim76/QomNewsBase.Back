using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;

public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
{
    public CreateNewsCommandValidator(INewsGroupRepository newsGroupRepository)
    {
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title Can't be null !")
            .NotEmpty().WithMessage("Title Can't be Empty")
            .MaximumLength(150);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description con't be Empty")
            .NotNull().WithMessage("Description con't be Null");

        RuleFor(x => x.NewsGroupId)
            .NotEmpty()
            .Must(newsGroupRepository.Any)
            .WithMessage("The specified newsGroup item does not exist.");

    }
}