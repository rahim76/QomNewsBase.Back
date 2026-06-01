using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;

public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
{
    public UpdateNewsCommandValidator(INewsRepository newsRepository, INewsGroupRepository newsGroupRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(newsRepository.Any)
            .WithMessage("The specified news item does not exist.");

        RuleFor(x => x.NewsGroupId)
            .NotEmpty()
            .Must(newsGroupRepository.Any)
            .WithMessage("The specified newsGroup item does not exist.");

        RuleFor(a => a.Title)
            .NotEmpty().WithMessage("can't be Empty !")
            .NotNull().WithMessage("can't be Null !")
            .MaximumLength(150).WithMessage("It cannot be more than 150 characters !");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description con't be Empty")
            .NotNull().WithMessage("Description con't be Null");


    }
}