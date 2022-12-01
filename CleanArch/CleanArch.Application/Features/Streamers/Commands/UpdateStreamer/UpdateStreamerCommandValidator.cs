using FluentValidation;

namespace CleanArch.Application.Features.Streamers.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull().WithMessage("{Name} must not be null.")
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{Url} is required.")
                .NotNull().WithMessage("{Name} must not be null.")
                .MaximumLength(50).WithMessage("{Url} must not exceed 50 characters.");
        }
    }
}
