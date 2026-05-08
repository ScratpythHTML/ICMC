using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Crashpads.Add;
using Services.Crashpads.Delete;
using Services.Crashpads.Get;
using Services.Crashpads.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to crashpads.
/// </summary>
[ApiController]
[Route("crashpads")]
public class CrashpadsController : ControllerBase
{
  private readonly IGetCrashpadService _getCrashpadService;
  private readonly IGetCrashpadsService _getCrashpadsService;
  private readonly IDeleteCrashpadService _deleteCrashpadService;
  private readonly IAddCrashpadService _addCrashpadService;
  private readonly IUpdateCrashpadService _updateCrashpadService;

  public CrashpadsController(
    IGetCrashpadService getCrashpadService,
    IGetCrashpadsService getCrashpadsService,
    IDeleteCrashpadService deleteCrashpadService,
    IAddCrashpadService addCrashpadService,
    IUpdateCrashpadService updateCrashpadService
  )
  {
    _getCrashpadService = getCrashpadService;
    _getCrashpadsService = getCrashpadsService;
    _deleteCrashpadService = deleteCrashpadService;
    _addCrashpadService = addCrashpadService;
    _updateCrashpadService = updateCrashpadService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetCrashpad(int id, CancellationToken cancellationToken)
  {
    var request = new GetCrashpadRequest(id);
    var result = await _getCrashpadService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpGet]
  public async Task<IActionResult> GetCrashpads(StorageLocation storageLocation, CancellationToken cancellationToken)
  {
    var request = new GetCrashpadsRequest(storageLocation);
    var result = await _getCrashpadsService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }
    return BadRequest(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCrashpad(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteCrashpadRequest(id);
    var result = await _deleteCrashpadService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddCrashpad(AddCrashpadRequest request, CancellationToken cancellationToken)
  {
    var result = await _addCrashpadService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateCrashpad(int id, UpdateCrashpadRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateCrashpadService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
