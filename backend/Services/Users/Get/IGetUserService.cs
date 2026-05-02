using Audacia.Commands;
using MediatR;

namespace Services.Users.Get;

/// <summary>
/// The inferface for the service that gets a user.
/// </summary>
public interface IGetUserService : IRequestHandler<GetUserRequest, CommandResult<UserDto>>
{
}
