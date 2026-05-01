using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Handlers.BelayDevices.Get;

/// <summary>
/// The handler that gets a belay device.
/// </summary>
public class GetBelayDeviceHandler : IGetBelayDeviceHandler
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetBelayDeviceHandler(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<BelayDeviceDto>> Handle(GetBelayDeviceRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.BelayDevices
        .Where(bd => bd.Id == request.Id)
        .Select(bd => new BelayDeviceDto
        {
          Id = request.Id,
          ToughTag = bd.ToughTag
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<BelayDeviceDto>("No belay device found");
    }

    return CommandResult.WithResult(result);
  }
}