using Audacia.Commands;
using MediatR;


namespace Handlers.Users.Add;

/// <summary>
/// A request to add a user.
/// </summary>
/// <param name="CID"></param>
/// <param name="FirstName"></param>
/// <param name="SecondName"></param>
/// <param name="UserEmail"></param>
/// <param name="IsAdmin"></param>
public record AddUserRequest(string? CID, string? FirstName, string? SecondName, string? UserEmail, bool? IsAdmin) : IRequest<CommandResult>
{
}
