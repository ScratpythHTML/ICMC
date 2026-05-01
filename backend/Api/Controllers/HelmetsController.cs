using Handlers.Helmets.Add;
using Handlers.Helmets.Delete;
using Handlers.Helmets.Get;
using Handlers.Helmets.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to helmets.
/// </summary>
[ApiController]
[Route("helmets")]
public class HelmetsController : ControllerBase
{
  private readonly GetHelmetHandler _getHelmetHandler;
  private readonly DeleteHelmetHandler _deleteHelmetHandler;
  private readonly AddHelmetHandler _addHelmetHandler;
  private readonly UpdateHelmetHandler _updateHelmetHandler;

  public HelmetsController(
    GetHelmetHandler getHelmetHandler,
    DeleteHelmetHandler deleteHelmetHandler,
    AddHelmetHandler addHelmetHandler,
    UpdateHelmetHandler updateHelmetHandler
  )
  {
    _getHelmetHandler = getHelmetHandler;
    _deleteHelmetHandler = deleteHelmetHandler;
    _addHelmetHandler = addHelmetHandler;
    _updateHelmetHandler = updateHelmetHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetHelmet(int id, CancellationToken cancellationToken)
  {
    var request = new GetHelmetRequest(id);
    var result = await _getHelmetHandler.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteHelmet(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteHelmetRequest(id);
    var result = await _deleteHelmetHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddHelmet(AddHelmetRequest request, CancellationToken cancellationToken)
  {
    var result = await _addHelmetHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateHelmet(UpdateHelmetRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateHelmetHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
