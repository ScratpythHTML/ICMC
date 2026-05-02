using Audacia.Commands;
using EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.BelayDevices.Delete;

/// <summary>
/// The service that deletes a belay device.
/// </summary>
public class DeleteBelayDeviceService : IDeleteBelayDeviceService
{
  private readonly DatabaseContext _context;
  /// <summary>
  /// The constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public DeleteBelayDeviceService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Handles deleting a belay device.
  /// </summary>
  /// <param name="request"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public async Task<CommandResult> Handle(DeleteBelayDeviceRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.BelayDevices
        .FirstOrDefaultAsync(bd => bd.Id == request.Id)
        .ConfigureAwait(false);

    if (result == null)
    {
      return CommandResult.Failure("Belay device not found.");
    }

    _context.BelayDevices.Remove(result);

    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return CommandResult.Success();

  }
}