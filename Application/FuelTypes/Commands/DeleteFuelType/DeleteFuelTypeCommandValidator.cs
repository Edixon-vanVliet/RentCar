using FluentValidation;

namespace RentCar.Application.FuelTypes.Commands.DeleteFuelType;

public class DeleteFuelTypeCommandValidator : AbstractValidator<DeleteFuelTypeCommand>
{
    public DeleteFuelTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }
}
