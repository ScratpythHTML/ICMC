using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.Users.Add;

/// <summary>
/// A request to add a user.
/// </summary>
public record AddUserRequest(
    string CID,
    string? Email,
    string? FullName,
    bool? IsAdmin,
    MemberType? MemberType
) : IRequest<CommandResult>;