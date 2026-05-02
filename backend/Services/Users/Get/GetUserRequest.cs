using MediatR;
using Audacia.Commands;

namespace Services.Users.Get;

/// <summary>
/// A request to get a user by ID.
/// </summary>
/// <param name="UserId"></param>
public record GetUserRequest(Guid UserId) : IRequest<CommandResult<UserDto>>;
