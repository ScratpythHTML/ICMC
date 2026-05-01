using Handlers.BelayDevices.Add;
using Handlers.BelayDevices.Delete;
using Handlers.BelayDevices.Get;
using Handlers.BelayDevices.Update;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for requests relating to belay devices.
/// </summary>
[ApiController]
[Route("belay-devices")]
public class BelayDevicesController : ControllerBase
{
  private readonly GetBelayDeviceHandler _getBelayDeviceHandler;
  private readonly DeleteBelayDeviceHandler _deleteBelayDeviceHandler;
  private readonly AddBelayDeviceHandler _addBelayDeviceHandler;
  private readonly UpdateBelayDeviceHandler _updateBelayDeviceHandler;

  public BelayDevicesController(
    GetBelayDeviceHandler getBelayDeviceHandler,
    DeleteBelayDeviceHandler deleteBelayDeviceHandler,
    AddBelayDeviceHandler addBelayDeviceHandler,
    UpdateBelayDeviceHandler updateBelayDeviceHandler
  )
  {
    _getBelayDeviceHandler = getBelayDeviceHandler;
    _deleteBelayDeviceHandler = deleteBelayDeviceHandler;
    _addBelayDeviceHandler = addBelayDeviceHandler;
    _updateBelayDeviceHandler = updateBelayDeviceHandler;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetBelayDevice(int id, CancellationToken cancellationToken)
  {
    var request = new GetBelayDeviceRequest(id);
    var result = await _getBelayDeviceHandler.Handle(request, cancellationToken).ConfigureAwait(false);

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
    var result = await _deleteBelayDeviceHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

  [HttpPost]
  public async Task<IActionResult> AddBelayDevice(AddBelayDeviceRequest request, CancellationToken cancellationToken)
  {
    var result = await _addBelayDeviceHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return Created();
    }
    return BadRequest(result.Errors);
  }


  [HttpPatch]
  public async Task<IActionResult> UpdateBelayDevice(UpdateBelayDeviceRequest request, CancellationToken cancellationToken)
  {
    var result = await _updateBelayDeviceHandler.Handle(request, cancellationToken);

    if (result.IsSuccess)
    {
      return NoContent();
    }

    return BadRequest(result.Errors);
  }

}