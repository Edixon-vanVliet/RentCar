using FluentValidation;

namespace RentCar.Application.VehicleTypes.Commands.DeleteVehicleType;

public class DeleteVehicleTypeCommandValidator : AbstractValidator<DeleteVehicleTypeCommand>
{
    public DeleteVehicleTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }
}
