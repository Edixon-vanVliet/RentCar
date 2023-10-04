using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Brands.Commands.CreateBrand;
using RentCar.Application.Brands.Commands.DeleteBrand;
using RentCar.Application.Brands.Commands.UpdateBrand;
using RentCar.Application.Brands.Queries.GetBrand;
using RentCar.Application.Brands.Queries.GetBrands;
using RentCar.WebUI.Controllers;

namespace WebUI.Controllers;

//[Authorize]
public class BrandsController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetBrands([FromQuery] GetBrandsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBrand(int id, GetBrandQuery query)
    {
        if (id != query.Id)
        {
            return BadRequest();
        }

        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateBrand(int id, UpdateBrandCommand command)
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
    public async Task<IActionResult> DeleteBrand(int id)
    {
        await Mediator.Send(new DeleteBrandCommand(id));

        return NoContent();
    }
}
