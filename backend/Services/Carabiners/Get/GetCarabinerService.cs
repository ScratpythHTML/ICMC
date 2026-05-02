using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Services.Carabiners.Get;

/// <summary>
/// The service that gets a carabiner.
/// </summary>
public class GetCarabinerService : IGetCarabinerService
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetCarabinerService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<CarabinerDto>> Handle(GetCarabinerRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Carabiners
        .Where(c => c.Id == request.Id)
        .Select(c => new CarabinerDto
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
      return CommandResult.Failure<CarabinerDto>("No carabiner found");
    }

    return CommandResult.WithResult(result);
  }
}
