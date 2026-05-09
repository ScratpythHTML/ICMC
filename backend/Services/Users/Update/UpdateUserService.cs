using Audacia.Commands;
using EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Services.Users.Update;

/// <summary>
/// The service for updating a user.
/// </summary>
public class UpdateUserService : IUpdateUserService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public UpdateUserService(
        DatabaseContext context
    )
    {
        _context = context;
    }

    /// <summary>
    /// Handles updating a user.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException();
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.CID == request.CID, cancellationToken)
            .ConfigureAwait(false);

        if (user == null)
        {
            return CommandResult.Failure("User not found");
        }

        user.FirstName = request.FirstName ?? user.FirstName;
        user.Email = request.Email ?? user.Email;
        user.IsAdmin = request.IsAdmin ?? user.IsAdmin;
        user.MemberType = request.MemberType ?? user.MemberType;
        user.Surname = request.Surname ?? user.Surname;

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
