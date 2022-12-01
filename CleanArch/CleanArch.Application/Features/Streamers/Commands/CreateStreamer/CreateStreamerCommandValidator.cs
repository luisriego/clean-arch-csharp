using FluentValidation;

namespace CleanArch.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull().WithMessage("The Name can´t be null.")
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(p => p.Url)
                .NotEmpty().WithMessage("{Url} is required.")
                .NotNull().WithMessage("The URL can´t be null.")
                .MaximumLength(150).WithMessage("{Url} must not exceed 150 characters.");
        }
    }
}
