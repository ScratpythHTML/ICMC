using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Quickdraws.Get;

/// <summary>
/// The handler that gets a quickdraw.
/// </summary>
public class GetQuickdrawHandler : IGetQuickdrawHandler
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetQuickdrawHandler(
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
          Id = request.Id,
          ToughTag = q.ToughTag,
          Brand = q.Brand,
          Model = q.Model,
          DateOfPurchase = q.DateOfPurchase,
          ManufacturerExpiry = q.ManufacturerExpiry,
          LastInspection = q.LastInspection,
          NextInspection = q.NextInspection,
          InspectedBy = q.InspectedBy
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
