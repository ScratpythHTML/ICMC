using Audacia.Commands;
using MediatR;
using Services.Users.Dtos;

namespace Services.Users.Search;

/// <summary>
/// The interface for the service that searches for users.
/// </summary>
public interface ISearchUsersService : IRequestHandler<SearchUsersRequest, CommandResult<UserDto[]>>;