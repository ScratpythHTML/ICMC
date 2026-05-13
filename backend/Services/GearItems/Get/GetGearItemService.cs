using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.GearItems.Dtos;

namespace Services.GearItems.Get;

/// <summary>
/// The service that gets a gear item.
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
        (
          gi.Id,
          gi.Brand,
          gi.DateOfPurchase,
          gi.ExpectedReturnDate,
          gi.GearCategory,
          gi.ImageUrl,
          gi.InspectedByUserId,
          gi.LastInspection,
          gi.Length,
          gi.LentByUserId,
          gi.LentDate,
          gi.LentToUserId,
          gi.LentToUser != null ? gi.LentToUser.FullName : null,
          gi.ManufacturerExpiry,
          gi.Model,
          gi.NextInspection,
          gi.ReturnedDate,
          gi.Sex,
          gi.Size,
          gi.StorageLocation,
          gi.ToughTag
        ))
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<GearItemDto>("No gear item found");
    }

    return CommandResult.WithResult(result);
  }
}