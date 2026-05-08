using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Helmets.Add;
using Services.Helmets.Delete;
using Services.Helmets.Get;
using Services.Helmets.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to helmets.
/// </summary>
[ApiController]
[Route("helmets")]
public class HelmetsController : ControllerBase
{
  private readonly IGetHelmetService _getHelmetService;
  private readonly IGetHelmetsService _getHelmetsService;
  private readonly IDeleteHelmetService _deleteHelmetService;
  private readonly IAddHelmetService _addHelmetService;
  private readonly IUpdateHelmetService _updateHelmetService;

  public HelmetsController(
    IGetHelmetService getHelmetService,
    IGetHelmetsService getHelmetsService,
    IDeleteHelmetService deleteHelmetService,
    IAddHelmetService addHelmetService,
    IUpdateHelmetService updateHelmetService
  )
  {
    _getHelmetService = getHelmetService;
    _getHelmetsService = getHelmetsService;
    _deleteHelmetService = deleteHelmetService;
    _addHelmetService = addHelmetService;
    _updateHelmetService = updateHelmetService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetHelmet(int id, CancellationToken cancellationToken)
  {
    var request = new GetHelmetRequest(id);
    var result = await _getHelmetService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpGet]
  public async Task<IActionResult> GetHelmets(StorageLocation storageLocation, CancellationToken cancellationToken)
  {
    var request = new GetHelmetsRequest(storageLocation);
    var result = await _getHelmetsService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }
    return BadRequest(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteHelmet(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteHelmetRequest(id);
    var result = await _deleteHelmetService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddHelmet(AddHelmetRequest request, CancellationToken cancellationToken)
  {
    var result = await _addHelmetService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateHelmet(int id, UpdateHelmetRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateHelmetService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
