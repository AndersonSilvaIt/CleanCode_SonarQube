using AnimalManager.Application.DTOs;
using FluentValidation;

namespace AnimalManager.Application.Validators
{
    public class AnimalDtoValidator : AbstractValidator<AnimalDto>
    {
        public AnimalDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("The name is required.");
            RuleFor(a => a.Species).NotEmpty().WithMessage("The species is required.");
            RuleFor(a => a.Age).GreaterThan(0).WithMessage("The age must be greater than zero.");
        }
    }
}
