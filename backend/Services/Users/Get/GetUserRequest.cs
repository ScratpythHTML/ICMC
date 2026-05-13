using Audacia.Commands;
using MediatR;
using Services.Users.Dtos;

namespace Services.Users.Get;

/// <summary>
/// A request to get a user by Id.
/// </summary>
/// <param name="Id"></param>
public record GetUserRequest(int Id) : IRequest<CommandResult<UserDto>>;
