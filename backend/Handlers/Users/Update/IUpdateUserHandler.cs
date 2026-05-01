using Audacia.Commands;
using MediatR;

namespace Handlers.Users.Update;

/// <summary>
/// The interface for the handler that updates a user.
/// </summary>
public interface IUpdateUserHandler : IRequestHandler<UpdateUserRequest, CommandResult>
{
}
