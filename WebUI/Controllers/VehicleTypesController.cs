using Microsoft.AspNetCore.Mvc;
using RentCar.Application.VehicleTypes.Commands.CreateVehicleType;
using RentCar.Application.VehicleTypes.Commands.DeleteVehicleType;
using RentCar.Application.VehicleTypes.Commands.UpdateVehicleType;
using RentCar.Application.VehicleTypes.Queries.GetVehicleType;
using RentCar.Application.VehicleTypes.Queries.GetVehicleTypes;
using RentCar.WebUI.Controllers;

namespace WebUI.Controllers;

//[Authorize]
public class VehicleTypesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetVehicleTypes([FromQuery] GetVehicleTypesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVehicleType(int id, GetVehicleTypeQuery query)
    {
        if (id != query.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicleType(CreateVehicleTypeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateVehicleType(int id, UpdateVehicleTypeCommand command)
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
    public async Task<IActionResult> DeleteVehicleType(int id)
    {
        await Mediator.Send(new DeleteVehicleTypeCommand(id));

        return NoContent();
    }
}
