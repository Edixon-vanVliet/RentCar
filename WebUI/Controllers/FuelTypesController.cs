using Microsoft.AspNetCore.Mvc;
using RentCar.Application.FuelTypes.Commands.CreateFuelType;
using RentCar.Application.FuelTypes.Commands.DeleteFuelType;
using RentCar.Application.FuelTypes.Commands.UpdateFuelType;
using RentCar.Application.FuelTypes.Queries.GetFuelType;
using RentCar.Application.FuelTypes.Queries.GetFuelTypes;
using RentCar.WebUI.Controllers;

namespace WebUI.Controllers;

//[Authorize]
public class FuelTypesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFuelTypes([FromQuery] GetFuelTypesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFuelType(int id, GetFuelTypeQuery query)
    {
        if (id != query.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateFuelType(CreateFuelTypeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateFuelType(int id, UpdateFuelTypeCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteFuelType(int id)
    {
        await Mediator.Send(new DeleteFuelTypeCommand(id));

        return NoContent();
    }
}
