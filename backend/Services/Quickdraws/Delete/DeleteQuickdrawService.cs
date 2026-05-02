using Audacia.Commands;
using EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Services.Quickdraws.Delete;

/// <summary>
/// The service that deletes a quickdraw.
/// </summary>
public class DeleteQuickdrawService : IDeleteQuickdrawService
{
  private readonly DatabaseContext _context;
  /// <summary>
  /// The constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public DeleteQuickdrawService(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Handles deleting a quickdraw.
  /// </summary>
  /// <param name="request"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public async Task<CommandResult> Handle(DeleteQuickdrawRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Quickdraws
        .FirstOrDefaultAsync(q => q.Id == request.Id)
        .ConfigureAwait(false);

    if (result == null)
    {
      return CommandResult.Failure();
    }

    _context.Quickdraws.Remove(result);

    await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    return CommandResult.Success();

  }
}
