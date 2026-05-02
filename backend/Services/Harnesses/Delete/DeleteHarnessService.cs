using Audacia.Commands;
using EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.Harnesses.Delete;

/// <summary>
/// The service that deletes a harness.
/// </summary>
public class DeleteHarnessService : IDeleteHarnessService
{
  private readonly DatabaseContext _context;
  /// <summary>
  /// The constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public DeleteHarnessService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Handles deleting a harness.
  /// </summary>
  /// <param name="request"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public async Task<CommandResult> Handle(DeleteHarnessRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Harnesses
        .FirstOrDefaultAsync(h => h.Id == request.Id)
        .ConfigureAwait(false);

    if (result == null)
    {
      return CommandResult.Failure();
    }

    _context.Harnesses.Remove(result);

    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return CommandResult.Success();

  }
}
