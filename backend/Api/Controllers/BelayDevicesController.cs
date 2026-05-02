using Microsoft.AspNetCore.Mvc;
using Services.BelayDevices.Add;
using Services.BelayDevices.Delete;
using Services.BelayDevices.Get;
using Services.BelayDevices.Update;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to belay devices.
/// </summary>
[ApiController]
[Route("belay-devices")]
public class BelayDevicesController : ControllerBase
{
  private readonly IGetBelayDeviceService _getBelayDeviceService;
  private readonly IDeleteBelayDeviceService _deleteBelayDeviceService;
  private readonly IAddBelayDeviceService _addBelayDeviceService;
  private readonly IUpdateBelayDeviceService _updateBelayDeviceService;

  public BelayDevicesController(
    IGetBelayDeviceService getBelayDeviceService,
    IDeleteBelayDeviceService deleteBelayDeviceService,
    IAddBelayDeviceService addBelayDeviceService,
    IUpdateBelayDeviceService updateBelayDeviceService
  )
  {
    _getBelayDeviceService = getBelayDeviceService;
    _deleteBelayDeviceService = deleteBelayDeviceService;
    _addBelayDeviceService = addBelayDeviceService;
    _updateBelayDeviceService = updateBelayDeviceService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetBelayDevice(int id, CancellationToken cancellationToken)
  {
    var request = new GetBelayDeviceRequest(id);
    var result = await _getBelayDeviceService.Handle(request, cancellationToken).ConfigureAwait(false);

    if (result.IsSuccess)
    {
      return Ok(result.Output);
    }

    return NotFound(result.Errors);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteBelayDevice(int id, CancellationToken cancellationToken)
  {
    var request = new DeleteBelayDeviceRequest(id);
    var result = await _deleteBelayDeviceService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddBelayDevice(AddBelayDeviceRequest request, CancellationToken cancellationToken)
  {
    var result = await _addBelayDeviceService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch("{id}")]
  public async Task<IActionResult> UpdateBelayDevice(int id, UpdateBelayDeviceRequest request, CancellationToken cancellationToken)
  {
    if (id != request.Id)
    {
      return BadRequest("Id in URL must match Id in request body");
    }

    var result = await _updateBelayDeviceService.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

}