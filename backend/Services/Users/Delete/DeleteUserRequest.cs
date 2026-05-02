using Audacia.Commands;
using MediatR;

namespace Services.Users.Delete;

/// <summary>
/// A request to delete a user by ID.
/// </summary>
/// <param name="UserId"></param>
public record DeleteUserRequest(Guid UserId) : IRequest<CommandResult>;
