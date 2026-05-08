using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Ropes.Add;
using Services.Ropes.Delete;
using Services.Ropes.Get;
using Services.Ropes.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to ropes.
/// </summary>
[ApiController]
[Route("ropes")]
public class RopesController : ControllerBase
{
  private readonly IGetRopeService _getRopeService;
  private readonly IGetRopesService _getRopesService;
  private readonly IDeleteRopeService _deleteRopeService;
  private readonly IAddRopeService _addRopeService;
  private readonly IUpdateRopeService _updateRopeService;

  public RopesController(
    IGetRopeService getRopeService,
    IGetRopesService getRopesService,
    IDeleteRopeService deleteRopeService,
    IAddRopeService addRopeService,
    IUpdateRopeService updateRopeService
  )
  {
    _getRopeService = getRopeService;
    _getRopesService = getRopesService;
    _deleteRopeService = deleteRopeService;
    _addRopeService = addRopeService;
    _updateRopeService = updateRopeService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetRope(int id, CancellationToken cancellationToken)
  {
    var request = new GetRopeRequest(id);
    var result = await _getRopeService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpGet]
  public async Task<IActionResult> GetRopes(StorageLocation storageLocation, CancellationToken cancellationToken)
  {
    var request = new GetRopesRequest(storageLocation);
    var result = await _getRopesService.Handle(request, cancellationToken).ConfigureAwait(false);
    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }
    return BadRequest(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteRope(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteRopeRequest(id);
    var result = await _deleteRopeService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddRope(AddRopeRequest request, CancellationToken cancellationToken)
  {
    var result = await _addRopeService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateRope(int id, UpdateRopeRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateRopeService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }
}
