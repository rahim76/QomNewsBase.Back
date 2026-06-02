using FluentValidation;

namespace QomNewsBase.Application.CQRS;

public class CreateAdCommandValidation : AbstractValidator<CreateAdCommand>
{
    public CreateAdCommandValidation()
    {
        RuleFor(a => a.Title)
            .NotEmpty().WithMessage("title can't be empty.")
            .NotNull().WithMessage("title can't be null.")
            .MaximumLength(250).WithMessage("title length can't exceed 250 characters.");

        RuleFor(a => a.TargetUrl)
            .NotNull().WithMessage("targetUrl can't be null.")
            .NotEmpty().WithMessage("targetUrl can't be empty.")
            .MaximumLength(1000).WithMessage("targetUrl length can't exceed 1000 characters.");

        RuleFor(a => a.PositionType)
            .NotNull()
            .IsInEnum().WithMessage("PositionType is invalid.");

    }
}