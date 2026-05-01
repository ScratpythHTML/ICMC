using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Helmets.Get;

/// <summary>
/// The handler that gets a helmet.
/// </summary>
public class GetHelmetHandler : IGetHelmetHandler
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetHelmetHandler(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<HelmetDto>> Handle(GetHelmetRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Helmets
        .Where(h => h.Id == request.Id)
        .Select(h => new HelmetDto
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
          Size = h.Size
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<HelmetDto>("No helmet found");
    }

    return CommandResult.WithResult(result);
  }
}
