using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Crashpads.Delete;

/// <summary>
/// The handler that deletes a crashpad.
/// </summary>
public class DeleteCrashpadHandler : IDeleteCrashpadHandler
{
  private readonly DatabaseContext _context;
  /// <summary>
  /// The constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public DeleteCrashpadHandler(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Handles deleting a crashpad.
  /// </summary>
  /// <param name="request"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public async Task<CommandResult> Handle(DeleteCrashpadRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Crashpads
        .FirstOrDefaultAsync(c => c.Id == request.Id)
        .ConfigureAwait(false);

    if (result == null)
    {
      return CommandResult.Failure();
    }

    _context.Crashpads.Remove(result);

    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return CommandResult.Success();

  }
}
