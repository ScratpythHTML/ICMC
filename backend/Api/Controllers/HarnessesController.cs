using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Harnesses.Add;
using Services.Harnesses.Delete;
using Services.Harnesses.Get;
using Services.Harnesses.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to harnesses.
/// </summary>
[ApiController]
[Route("harnesses")]
public class HarnessesController : ControllerBase
{
  private readonly IGetHarnessService _getHarnessService;
  private readonly IGetHarnessesService _getHarnessesService;
  private readonly IDeleteHarnessService _deleteHarnessService;
  private readonly IAddHarnessService _addHarnessService;
  private readonly IUpdateHarnessService _updateHarnessService;

  public HarnessesController(
    IGetHarnessService getHarnessService,
    IGetHarnessesService getHarnessesService,
    IDeleteHarnessService deleteHarnessService,
    IAddHarnessService addHarnessService,
    IUpdateHarnessService updateHarnessService
  )
  {
    _getHarnessService = getHarnessService;
    _getHarnessesService = getHarnessesService;
    _deleteHarnessService = deleteHarnessService;
    _addHarnessService = addHarnessService;
    _updateHarnessService = updateHarnessService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetHarness(int id, CancellationToken cancellationToken)
  {
    var request = new GetHarnessRequest(id);
    var result = await _getHarnessService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpGet]
  public async Task<IActionResult> GetHarnesses(StorageLocation storageLocation, CancellationToken cancellationToken)
  {
    var request = new GetHarnessesRequest(storageLocation);
    var result = await _getHarnessesService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }
    return BadRequest(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteHarness(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteHarnessRequest(id);
    var result = await _deleteHarnessService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddHarness(AddHarnessRequest request, CancellationToken cancellationToken)
  {
    var result = await _addHarnessService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateHarness(int id, UpdateHarnessRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateHarnessService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
