using Audacia.Commands;
using MediatR;

namespace Services.Users.Add;

/// <summary>
/// The interface for the service that adds a user.
/// </summary>
public interface IAddUserService : IRequestHandler<AddUserRequest, CommandResult>
{
}
