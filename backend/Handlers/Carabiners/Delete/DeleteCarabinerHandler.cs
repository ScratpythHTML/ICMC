using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Carabiners.Delete;

/// <summary>
/// The handler that deletes a carabiner.
/// </summary>
public class DeleteCarabinerHandler : IDeleteCarabinerHandler
{
  private readonly DatabaseContext _context;
  /// <summary>
  /// The constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public DeleteCarabinerHandler(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Handles deleting a carabiner.
  /// </summary>
  /// <param name="request"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public async Task<CommandResult> Handle(DeleteCarabinerRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Carabiners
        .FirstOrDefaultAsync(c => c.Id == request.Id)
        .ConfigureAwait(false);

    if (result == null)
    {
      return CommandResult.Failure();
    }

    _context.Carabiners.Remove(result);

    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return CommandResult.Success();

  }
}
