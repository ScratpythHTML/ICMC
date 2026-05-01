using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Crashpads.Get;

/// <summary>
/// The handler that gets a crashpad.
/// </summary>
public class GetCrashpadHandler : IGetCrashpadHandler
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetCrashpadHandler(
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
          Id = request.Id,
          ToughTag = c.ToughTag,
          Brand = c.Brand,
          Model = c.Model,
          DateOfPurchase = c.DateOfPurchase,
          ManufacturerExpiry = c.ManufacturerExpiry,
          LastInspection = c.LastInspection,
          NextInspection = c.NextInspection,
          InspectedBy = c.InspectedBy
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
