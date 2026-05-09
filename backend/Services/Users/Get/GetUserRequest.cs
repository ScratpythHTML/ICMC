using Audacia.Commands;
using MediatR;

namespace Services.Users.Get;

/// <summary>
/// A request to get a user by CID.
/// </summary>
/// <param name="CID"></param>
public record GetUserRequest(int CID) : IRequest<CommandResult<UserDto>>;
