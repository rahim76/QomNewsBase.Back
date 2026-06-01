using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;

public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
{
    public DeleteNewsCommandValidator(INewsRepository newsRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(newsRepository.Any)
            .WithMessage("The specified news item does not exist.");

    }
}