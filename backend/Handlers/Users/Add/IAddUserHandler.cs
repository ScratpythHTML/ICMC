using Audacia.Commands;
using MediatR;

namespace Handlers.Users.Add;

/// <summary>
/// The interface for the handler that adds a user.
/// </summary>
public interface IAddUserHandler : IRequestHandler<AddUserRequest, CommandResult>
{
}
