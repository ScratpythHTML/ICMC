using Audacia.Commands;
using Domain.Entities;
using MediatR;


namespace Services.Users.Update;

/// <summary>
/// A request to update a user.
/// </summary>
/// <param name="CID"></param>
/// <param name="FirstName"></param>
/// <param name="Email"></param>
/// <param name="IsAdmin"></param>
/// <param name="MemberType"></param>
/// <param name="Surname"></param>
public record UpdateUserRequest(int CID, string? FirstName, string? Email, bool? IsAdmin, MemberType? MemberType, string? Surname) : IRequest<CommandResult>
{
}
