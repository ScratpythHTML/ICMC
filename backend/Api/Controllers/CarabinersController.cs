using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Carabiners.Add;
using Services.Carabiners.Delete;
using Services.Carabiners.Get;
using Services.Carabiners.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to carabiners.
/// </summary>
[ApiController]
[Route("carabiners")]
public class CarabinersController : ControllerBase
{
  private readonly IGetCarabinerService _getCarabinerService;
  private readonly IGetCarabinersService _getCarabinersService;
  private readonly IDeleteCarabinerService _deleteCarabinerService;
  private readonly IAddCarabinerService _addCarabinerService;
  private readonly IUpdateCarabinerService _updateCarabinerService;

  public CarabinersController(
    IGetCarabinerService getCarabinerService,
    IGetCarabinersService getCarabinersService,
    IDeleteCarabinerService deleteCarabinerService,
    IAddCarabinerService addCarabinerService,
    IUpdateCarabinerService updateCarabinerService
  )
  {
    _getCarabinerService = getCarabinerService;
    _getCarabinersService = getCarabinersService;
    _deleteCarabinerService = deleteCarabinerService;
    _addCarabinerService = addCarabinerService;
    _updateCarabinerService = updateCarabinerService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetCarabiner(int id, CancellationToken cancellationToken)
  {
    var request = new GetCarabinerRequest(id);
    var result = await _getCarabinerService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpGet]
  public async Task<IActionResult> GetCarabiners(StorageLocation storageLocation, CancellationToken cancellationToken)
  {
    var request = new GetCarabinersRequest(storageLocation);
    var result = await _getCarabinersService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }
    return BadRequest(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCarabiner(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteCarabinerRequest(id);
    var result = await _deleteCarabinerService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddCarabiner(AddCarabinerRequest request, CancellationToken cancellationToken)
  {
    var result = await _addCarabinerService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateCarabiner(int id, UpdateCarabinerRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateCarabinerService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
