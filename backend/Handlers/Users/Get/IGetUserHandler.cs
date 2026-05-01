using MediatR;
using Audacia.Commands;

namespace Handlers.Users.Get;

/// <summary>
/// The inferface for the handler that gets a user.
/// </summary>
public interface IGetUserHandler : IRequestHandler<GetUserRequest, CommandResult<UserDto>>
{
}
