using Handlers.BelayDevices.Get;
using Handlers.BelayDevices.Delete;

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

  public BelayDevicesController(
    GetBelayDeviceHandler getBelayDeviceHandler,
    DeleteBelayDeviceHandler deleteBelayDeviceHandler
  )
  {
    _getBelayDeviceHandler = getBelayDeviceHandler;
    _deleteBelayDeviceHandler = deleteBelayDeviceHandler;
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

    return BadRequest();
  }

}