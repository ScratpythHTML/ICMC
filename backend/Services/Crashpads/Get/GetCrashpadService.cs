using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Services.Crashpads.Get;

/// <summary>
/// The service that gets a crashpad.
/// </summary>
public class GetCrashpadService : IGetCrashpadService
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetCrashpadService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<CrashpadDto>> Handle(GetCrashpadRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Crashpads
        .Where(c => c.Id == request.Id)
        .Select(c => new CrashpadDto
        {
          Id = c.Id,
          ToughTag = c.ToughTag,
          Brand = c.Brand,
          Model = c.Model,
          DateOfPurchase = c.DateOfPurchase,
          ManufacturerExpiry = c.ManufacturerExpiry,
          LastInspection = c.LastInspection,
          NextInspection = c.NextInspection,
          InspectedBy = c.InspectedBy,
          StorageLocation = c.StorageLocation,
          LentTo = c.LentTo,
          LentBy = c.LentBy,
          ReturnedDate = c.ReturnedDate
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<CrashpadDto>("No crashpad found");
    }

    return CommandResult.WithResult(result);
  }
}
