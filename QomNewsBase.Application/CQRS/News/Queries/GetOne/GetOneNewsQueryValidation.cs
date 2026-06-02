using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;

public class GetOneNewsQueryValidation : AbstractValidator<GetOneNewsQuery>
{
    public GetOneNewsQueryValidation(INewsRepository newsRepository)
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .NotNull()
            .MustAsync(newsRepository.Any).WithMessage("News Not Found !");
    }
}