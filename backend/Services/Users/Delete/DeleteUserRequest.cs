using Audacia.Commands;
using MediatR;

namespace Services.Users.Delete;

/// <summary>
/// A request to delete a user by Id.
/// </summary>
/// <param name="Id"></param>
public record DeleteUserRequest(int Id) : IRequest<CommandResult>;
