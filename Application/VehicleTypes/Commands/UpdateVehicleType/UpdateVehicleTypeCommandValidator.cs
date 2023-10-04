using FluentValidation;

namespace RentCar.Application.VehicleTypes.Commands.UpdateVehicleType;

public class UpdateVehicleTypeCommandValidator : AbstractValidator<UpdateVehicleTypeCommand>
{
    public UpdateVehicleTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
