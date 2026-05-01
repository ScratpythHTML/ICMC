using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Harnesses.Get;

/// <summary>
/// The handler that gets a harness.
/// </summary>
public class GetHarnessHandler : IGetHarnessHandler
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetHarnessHandler(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<HarnessDto>> Handle(GetHarnessRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Harnesses
        .Where(h => h.Id == request.Id)
        .Select(h => new HarnessDto
        {
          Id = request.Id,
          ToughTag = h.ToughTag,
          Brand = h.Brand,
          Model = h.Model,
          DateOfPurchase = h.DateOfPurchase,
          ManufacturerExpiry = h.ManufacturerExpiry,
          LastInspection = h.LastInspection,
          NextInspection = h.NextInspection,
          InspectedBy = h.InspectedBy,
          Size = h.Size,
          Sex = h.Sex
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<HarnessDto>("No harness found");
    }

    return CommandResult.WithResult(result);
  }
}
