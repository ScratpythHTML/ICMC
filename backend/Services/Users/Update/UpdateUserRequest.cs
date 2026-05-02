using Audacia.Commands;
using MediatR;


namespace Services.Users.Update;

/// <summary>
/// A request to update a user.
/// </summary>
/// <param name="userId"></param>
/// <param name="CID"></param>
/// <param name="FirstName"></param>
/// <param name="SecondName"></param>
/// <param name="UserEmail"></param>
/// <param name="IsAdmin"></param>
public record UpdateUserRequest(string userId, string? CID, string? FirstName, string? SecondName, string? UserEmail, bool? IsAdmin) : IRequest<CommandResult>
{
}
