using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Services.Ropes.Get;

/// <summary>
/// The service that gets a rope.
/// </summary>
public class GetRopeService : IGetRopeService
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetRopeService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<RopeDto>> Handle(GetRopeRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Ropes
        .Where(r => r.Id == request.Id)
        .Select(r => new RopeDto
        {
          Id = request.Id,
          ToughTag = r.ToughTag,
          Brand = r.Brand,
          Model = r.Model,
          DateOfPurchase = r.DateOfPurchase,
          ManufacturerExpiry = r.ManufacturerExpiry,
          LastInspection = r.LastInspection,
          NextInspection = r.NextInspection,
          InspectedBy = r.InspectedBy,
          Length = r.Length
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<RopeDto>("No rope found");
    }

    return CommandResult.WithResult(result);
  }
}
