using Handlers.Harnesses.Add;
using Handlers.Harnesses.Delete;
using Handlers.Harnesses.Get;
using Handlers.Harnesses.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to harnesses.
/// </summary>
[ApiController]
[Route("harnesses")]
public class HarnessesController : ControllerBase
{
  private readonly GetHarnessHandler _getHarnessHandler;
  private readonly DeleteHarnessHandler _deleteHarnessHandler;
  private readonly AddHarnessHandler _addHarnessHandler;
  private readonly UpdateHarnessHandler _updateHarnessHandler;

  public HarnessesController(
    GetHarnessHandler getHarnessHandler,
    DeleteHarnessHandler deleteHarnessHandler,
    AddHarnessHandler addHarnessHandler,
    UpdateHarnessHandler updateHarnessHandler
  )
  {
    _getHarnessHandler = getHarnessHandler;
    _deleteHarnessHandler = deleteHarnessHandler;
    _addHarnessHandler = addHarnessHandler;
    _updateHarnessHandler = updateHarnessHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetHarness(int id, CancellationToken cancellationToken)
  {
    var request = new GetHarnessRequest(id);
    var result = await _getHarnessHandler.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteHarness(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteHarnessRequest(id);
    var result = await _deleteHarnessHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddHarness(AddHarnessRequest request, CancellationToken cancellationToken)
  {
    var result = await _addHarnessHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateHarness(UpdateHarnessRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateHarnessHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
