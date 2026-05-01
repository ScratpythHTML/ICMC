using EntityFramework;
using Audacia.Commands;
using Microsoft.EntityFrameworkCore;

namespace Handlers.Users.Get;

/// <summary>
/// The handler that gets a user.
/// </summary>
public class GetUserHandler : IGetUserHandler
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetUserHandler(
    DatabaseContext context
  )
  {
    _context = context;
  }
  /// <summary>
  /// Method that handles the asynchronous operation.
  /// </summary>
  public async Task<CommandResult<UserDto>> Handle(GetUserRequest request, CancellationToken cancellationToken)
  {
    if (request == null)
    {
      throw new ArgumentNullException();
    }
    var result = await _context.Users
        .Where(u => u.UserId == request.UserId)
        .Select(u => new UserDto
        {
          UserId = request.UserId,
          CID = u.CID,
          FirstName = u.FirstName,
          SecondName = u.SecondName,
          UserEmail = u.UserEmail,
          IsAdmin = u.IsAdmin
        })
        .FirstOrDefaultAsync(cancellationToken)
        .ConfigureAwait(false);
    if (result == null)
    {
      return CommandResult.Failure<UserDto>("No user found");
    }

    return CommandResult.WithResult(result);
  }
}
