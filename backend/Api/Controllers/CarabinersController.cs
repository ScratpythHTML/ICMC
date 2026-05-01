using Handlers.Carabiners.Add;
using Handlers.Carabiners.Delete;
using Handlers.Carabiners.Get;
using Handlers.Carabiners.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to carabiners.
/// </summary>
[ApiController]
[Route("carabiners")]
public class CarabinersController : ControllerBase
{
  private readonly GetCarabinerHandler _getCarabinerHandler;
  private readonly DeleteCarabinerHandler _deleteCarabinerHandler;
  private readonly AddCarabinerHandler _addCarabinerHandler;
  private readonly UpdateCarabinerHandler _updateCarabinerHandler;

  public CarabinersController(
    GetCarabinerHandler getCarabinerHandler,
    DeleteCarabinerHandler deleteCarabinerHandler,
    AddCarabinerHandler addCarabinerHandler,
    UpdateCarabinerHandler updateCarabinerHandler
  )
  {
    _getCarabinerHandler = getCarabinerHandler;
    _deleteCarabinerHandler = deleteCarabinerHandler;
    _addCarabinerHandler = addCarabinerHandler;
    _updateCarabinerHandler = updateCarabinerHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetCarabiner(int id, CancellationToken cancellationToken)
  {
    var request = new GetCarabinerRequest(id);
    var result = await _getCarabinerHandler.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCarabiner(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteCarabinerRequest(id);
    var result = await _deleteCarabinerHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddCarabiner(AddCarabinerRequest request, CancellationToken cancellationToken)
  {
    var result = await _addCarabinerHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateCarabiner(UpdateCarabinerRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateCarabinerHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
