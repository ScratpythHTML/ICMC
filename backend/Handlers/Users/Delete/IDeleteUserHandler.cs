using Audacia.Commands;
using MediatR;

namespace Handlers.Users.Delete;

/// <summary>
/// The interface for the handler that deletes a user.
/// </summary>
public interface IDeleteUserHandler : IRequestHandler<DeleteUserRequest, CommandResult>
{
}
