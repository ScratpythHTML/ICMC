using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.BelayDevices.Get;

/// <summary>
/// The service that gets a belay device.
/// </summary>
public class GetBelayDeviceService : IGetBelayDeviceService
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetBelayDeviceService(
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
          Id = bd.Id,
          ToughTag = bd.ToughTag,
          Brand = bd.Brand,
          Model = bd.Model,
          DateOfPurchase = bd.DateOfPurchase,
          ManufacturerExpiry = bd.ManufacturerExpiry,
          LastInspection = bd.LastInspection,
          NextInspection = bd.NextInspection,
          InspectedBy = bd.InspectedBy,
          StorageLocation = bd.StorageLocation,
          LentTo = bd.LentTo,
          LentBy = bd.LentBy,
          ReturnedDate = bd.ReturnedDate
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