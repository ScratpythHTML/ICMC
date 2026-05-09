using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Services.Quickdraws.Get;

/// <summary>
/// The service that gets a quickdraw.
/// </summary>
public class GetQuickdrawService : IGetQuickdrawService
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetQuickdrawService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<QuickdrawDto>> Handle(GetQuickdrawRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Quickdraws
        .Where(q => q.Id == request.Id)
        .Select(q => new QuickdrawDto
        {
          Id = q.Id,
          ToughTag = q.ToughTag,
          Brand = q.Brand,
          Model = q.Model,
          DateOfPurchase = q.DateOfPurchase,
          ManufacturerExpiry = q.ManufacturerExpiry,
          LastInspection = q.LastInspection,
          NextInspection = q.NextInspection,
          InspectedBy = q.InspectedBy,
          StorageLocation = q.StorageLocation,
          LentTo = q.LentTo,
          LentBy = q.LentBy,
          ReturnedDate = q.ReturnedDate
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<QuickdrawDto>("No quickdraw found");
    }

    return CommandResult.WithResult(result);
  }
}
