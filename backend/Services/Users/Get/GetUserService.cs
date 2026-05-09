using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Users.Get;

/// <summary>
/// The service that gets a user.
/// </summary>
public class GetUserService : IGetUserService
{
  private readonly DatabaseContext _context;

  /// <summary>
  /// Constructor for the class.
  /// </summary>
  /// <param name="context"></param>
  public GetUserService(
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
        .Where(u => u.CID == request.CID)
        .Select(u => new UserDto
        {
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
