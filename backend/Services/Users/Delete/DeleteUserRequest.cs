using Audacia.Commands;
using MediatR;

namespace Services.Users.Delete;

/// <summary>
/// A request to delete a user by CID.
/// </summary>
/// <param name="CID"></param>
public record DeleteUserRequest(string CID) : IRequest<CommandResult>;
