using Audacia.Commands;
using Domain.Entities;
using EntityFramework;

namespace Handlers.Users.Add;

/// <summary>
/// The handler that adds a user.
/// </summary>
public class AddUserHandler : IAddUserHandler
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddUserHandler(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles adding a user.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var user = new User
        {
            CID = request.CID,
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            UserEmail = request.UserEmail,
            IsAdmin = request.IsAdmin
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
