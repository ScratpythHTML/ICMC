using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.GearItems.Get;

/// <summary>
/// The service that gets a belay device.
/// </summary>
public class GetGearItemService : IGetGearItemService
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetGearItemService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<GearItemDto>> Handle(GetGearItemRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.GearItems
        .Where(gi => gi.Id == request.Id)
        .Select(gi => new GearItemDto
        {
          Brand = gi.Brand,
          DateOfPurchase = gi.DateOfPurchase,
          GearCategory = gi.GearCategory,
          Id = gi.Id,
          InspectedBy = gi.InspectedBy,
          LastInspection = gi.LastInspection,
          Length = gi.Length,
          LentBy = gi.LentBy,
          LentDate = gi.LentDate,
          LentTo = gi.LentTo,
          ManufacturerExpiry = gi.ManufacturerExpiry,
          Model = gi.Model,
          NextInspection = gi.NextInspection,
          ReturnedDate = gi.ReturnedDate,
          Sex = gi.Sex,
          Size = gi.Size,
          StorageLocation = gi.StorageLocation,
          ToughTag = gi.ToughTag
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<GearItemDto>("No gear item found");
    }

    return CommandResult.WithResult(result);
  }
}