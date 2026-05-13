using Audacia.Commands;
using Domain.Entities;
using EntityFramework;

namespace Services.Users.Add;

/// <summary>
/// The service that adds a user.
/// </summary>
public class AddUserService : IAddUserService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class.
    /// </summary>
    /// <param name="context"></param>
    public AddUserService(
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
            FullName = request.FullName,
            Email = request.Email,
            IsAdmin = request.IsAdmin,
            MemberType = request.MemberType,
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return CommandResult.Success();
    }
}
