using Microsoft.AspNetCore.Mvc;
using Services.GearItems.Add;
using Services.GearItems.Delete;
using Services.GearItems.Get;
using Services.GearItems.Search;
using Services.GearItems.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to gear items.
/// </summary>
[ApiController]
[Route("gear-items")]
public class GearItemsController : ControllerBase
{
    private readonly IGetGearItemService _getGearItemService;
    private readonly ISearchGearItemsService _searchGearItemsService;
    private readonly IDeleteGearItemService _deleteGearItemService;
    private readonly IAddGearItemService _addGearItemService;
    private readonly IUpdateGearItemService _updateGearItemService;

    public GearItemsController(
      IGetGearItemService getGearItemService,
      ISearchGearItemsService searchGearItemsService,
      IDeleteGearItemService deleteGearItemService,
      IAddGearItemService addGearItemService,
      IUpdateGearItemService updateGearItemService
    )
    {
        _getGearItemService = getGearItemService;
        _searchGearItemsService = searchGearItemsService;
        _deleteGearItemService = deleteGearItemService;
        _addGearItemService = addGearItemService;
        _updateGearItemService = updateGearItemService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGearItem([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetGearItemRequest(id);
        var result = await _getGearItemService.Handle(request, cancellationToken).ConfigureAwait(false);

        if (result.IsSuccess)
        {
            return Ok(result.Output);
        }

        return NotFound(result.Errors);
    }

    [HttpGet]
    public async Task<IActionResult> SearchGearItems([FromQuery] SearchGearItemsRequest request, CancellationToken cancellationToken)
    {
        var result = await _searchGearItemsService.Handle(request, cancellationToken).ConfigureAwait(false);
        if (result.IsSuccess)
        {
            return Ok(result.Output);
        }
        return BadRequest(result.Errors);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGearItem(int id, CancellationToken cancellationToken)
    {
        var request = new DeleteGearItemRequest(id);
        var result = await _deleteGearItemService.Handle(request, cancellationToken);

        if (result.IsSuccess)
        {
            return NoContent();
        }

        return BadRequest(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> AddGearItem(AddGearItemRequest request, CancellationToken cancellationToken)
    {
        var result = await _addGearItemService.Handle(request, cancellationToken);

        if (result.IsSuccess)
        {
            return Created();
        }
        return BadRequest(result.Errors);
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateGearItem(int id, UpdateGearItemRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
        {
            return BadRequest("Id in URL must match Id in request body");
        }

        var result = await _updateGearItemService.Handle(request, cancellationToken);

        if (result.IsSuccess)
        {
            return NoContent();
        }

        return BadRequest(result.Errors);
    }
}