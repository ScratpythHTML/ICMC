using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Quickdraws.Add;
using Services.Quickdraws.Delete;
using Services.Quickdraws.Get;
using Services.Quickdraws.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to quickdraws.
/// </summary>
[ApiController]
[Route("quickdraws")]
public class QuickdrawsController : ControllerBase
{
  private readonly IGetQuickdrawService _getQuickdrawService;
  private readonly IGetQuickdrawsService _getQuickdrawsService;
  private readonly IDeleteQuickdrawService _deleteQuickdrawService;
  private readonly IAddQuickdrawService _addQuickdrawService;
  private readonly IUpdateQuickdrawService _updateQuickdrawService;

  public QuickdrawsController(
    IGetQuickdrawService getQuickdrawService,
    IGetQuickdrawsService getQuickdrawsService,
    IDeleteQuickdrawService deleteQuickdrawService,
    IAddQuickdrawService addQuickdrawService,
    IUpdateQuickdrawService updateQuickdrawService
  )
  {
    _getQuickdrawService = getQuickdrawService;
    _getQuickdrawsService = getQuickdrawsService;
    _deleteQuickdrawService = deleteQuickdrawService;
    _addQuickdrawService = addQuickdrawService;
    _updateQuickdrawService = updateQuickdrawService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetQuickdraw(int id, CancellationToken cancellationToken)
  {
    var request = new GetQuickdrawRequest(id);
    var result = await _getQuickdrawService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpGet]
  public async Task<IActionResult> GetQuickdraws(StorageLocation storageLocation, CancellationToken cancellationToken)
  {
    var request = new GetQuickdrawsRequest(storageLocation);
    var result = await _getQuickdrawsService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }
    return BadRequest(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteQuickdraw(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteQuickdrawRequest(id);
    var result = await _deleteQuickdrawService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddQuickdraw(AddQuickdrawRequest request, CancellationToken cancellationToken)
  {
    var result = await _addQuickdrawService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateQuickdraw(int id, UpdateQuickdrawRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateQuickdrawService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
