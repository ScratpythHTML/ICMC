using Handlers.Quickdraws.Add;
using Handlers.Quickdraws.Delete;
using Handlers.Quickdraws.Get;
using Handlers.Quickdraws.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to quickdraws.
/// </summary>
[ApiController]
[Route("quickdraws")]
public class QuickdrawsController : ControllerBase
{
  private readonly GetQuickdrawHandler _getQuickdrawHandler;
  private readonly DeleteQuickdrawHandler _deleteQuickdrawHandler;
  private readonly AddQuickdrawHandler _addQuickdrawHandler;
  private readonly UpdateQuickdrawHandler _updateQuickdrawHandler;

  public QuickdrawsController(
    GetQuickdrawHandler getQuickdrawHandler,
    DeleteQuickdrawHandler deleteQuickdrawHandler,
    AddQuickdrawHandler addQuickdrawHandler,
    UpdateQuickdrawHandler updateQuickdrawHandler
  )
  {
    _getQuickdrawHandler = getQuickdrawHandler;
    _deleteQuickdrawHandler = deleteQuickdrawHandler;
    _addQuickdrawHandler = addQuickdrawHandler;
    _updateQuickdrawHandler = updateQuickdrawHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetQuickdraw(int id, CancellationToken cancellationToken)
  {
    var request = new GetQuickdrawRequest(id);
    var result = await _getQuickdrawHandler.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteQuickdraw(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteQuickdrawRequest(id);
    var result = await _deleteQuickdrawHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddQuickdraw(AddQuickdrawRequest request, CancellationToken cancellationToken)
  {
    var result = await _addQuickdrawHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateQuickdraw(UpdateQuickdrawRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateQuickdrawHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
