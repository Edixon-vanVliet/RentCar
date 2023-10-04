using FluentValidation;

namespace RentCar.Application.FuelTypes.Commands.UpdateFuelType;

public class UpdateFuelTypeCommandValidator : AbstractValidator<UpdateFuelTypeCommand>
{
    public UpdateFuelTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
