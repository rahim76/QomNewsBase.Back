using FluentValidation;
using QomNewsBase.Application.Interfaces;

namespace QomNewsBase.Application.CQRS;
public class DeleteAdCommandValidation : AbstractValidator<DeleteAdCommand>
{
    public DeleteAdCommandValidation(IAdRepository adRepository)
    {
        RuleFor(a => a.Id)
            .NotNull()
            .MustAsync(adRepository.Any).WithMessage("ad not found !");
    }
}