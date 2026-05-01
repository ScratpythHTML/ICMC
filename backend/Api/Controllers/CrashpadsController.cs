using Handlers.Crashpads.Add;
using Handlers.Crashpads.Delete;
using Handlers.Crashpads.Get;
using Handlers.Crashpads.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to crashpads.
/// </summary>
[ApiController]
[Route("crashpads")]
public class CrashpadsController : ControllerBase
{
  private readonly GetCrashpadHandler _getCrashpadHandler;
  private readonly DeleteCrashpadHandler _deleteCrashpadHandler;
  private readonly AddCrashpadHandler _addCrashpadHandler;
  private readonly UpdateCrashpadHandler _updateCrashpadHandler;

  public CrashpadsController(
    GetCrashpadHandler getCrashpadHandler,
    DeleteCrashpadHandler deleteCrashpadHandler,
    AddCrashpadHandler addCrashpadHandler,
    UpdateCrashpadHandler updateCrashpadHandler
  )
  {
    _getCrashpadHandler = getCrashpadHandler;
    _deleteCrashpadHandler = deleteCrashpadHandler;
    _addCrashpadHandler = addCrashpadHandler;
    _updateCrashpadHandler = updateCrashpadHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetCrashpad(int id, CancellationToken cancellationToken)
  {
    var request = new GetCrashpadRequest(id);
    var result = await _getCrashpadHandler.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCrashpad(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteCrashpadRequest(id);
    var result = await _deleteCrashpadHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddCrashpad(AddCrashpadRequest request, CancellationToken cancellationToken)
  {
    var result = await _addCrashpadHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateCrashpad(UpdateCrashpadRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateCrashpadHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
