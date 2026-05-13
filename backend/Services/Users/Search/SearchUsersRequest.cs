using Audacia.Commands;
using Domain.Entities;
using MediatR;
using Services.Users.Dtos;

/// <summary>
/// The request that searches for users.
/// </summary>
/// <param name="CID"></param>
/// <param name="Email"></param>
/// <param name="FullName"></param>
/// <param name="IsAdmin"></param>
/// <param name="MemberType"></param>
public record SearchUsersRequest
(
    string? CID,
    string? Email,
    string? FullName,
    bool? IsAdmin,
    MemberType? MemberType
) : IRequest<CommandResult<UserDto[]>>;