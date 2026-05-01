using Handlers.Ropes.Add;
using Handlers.Ropes.Delete;
using Handlers.Ropes.Get;
using Handlers.Ropes.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to ropes.
/// </summary>
[ApiController]
[Route("ropes")]
public class RopesController : ControllerBase
{
  private readonly GetRopeHandler _getRopeHandler;
  private readonly DeleteRopeHandler _deleteRopeHandler;
  private readonly AddRopeHandler _addRopeHandler;
  private readonly UpdateRopeHandler _updateRopeHandler;

  public RopesController(
    GetRopeHandler getRopeHandler,
    DeleteRopeHandler deleteRopeHandler,
    AddRopeHandler addRopeHandler,
    UpdateRopeHandler updateRopeHandler
  )
  {
    _getRopeHandler = getRopeHandler;
    _deleteRopeHandler = deleteRopeHandler;
    _addRopeHandler = addRopeHandler;
    _updateRopeHandler = updateRopeHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetRope(int id, CancellationToken cancellationToken)
  {
    var request = new GetRopeRequest(id);
    var result = await _getRopeHandler.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteRope(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteRopeRequest(id);
    var result = await _deleteRopeHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddRope(AddRopeRequest request, CancellationToken cancellationToken)
  {
    var result = await _addRopeHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateRope(UpdateRopeRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateRopeHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
