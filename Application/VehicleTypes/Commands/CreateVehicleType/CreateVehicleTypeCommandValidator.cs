using FluentValidation;

namespace RentCar.Application.VehicleTypes.Commands.CreateVehicleType;

public class CreateVehicleTypeCommandValidator : AbstractValidator<CreateVehicleTypeCommand>
{
    public CreateVehicleTypeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
