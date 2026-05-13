using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Users.Dtos;

namespace Services.Users.Search;

public class SearchUsersService : ISearchUsersService
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// The constructor for the class
    /// </summary>
    /// <param name="context"></param>
    public SearchUsersService(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method that handles searching for users.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<CommandResult<UserDto[]>> Handle(SearchUsersRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var result = await _context.Users
            .Where(u =>
                (string.IsNullOrEmpty(request.CID) || (u.CID != null && u.CID.StartsWith(request.CID))) &&
                (string.IsNullOrEmpty(request.Email) || (u.Email != null && u.Email.StartsWith(request.Email))) &&
                (request.IsAdmin == null) || (request.IsAdmin == u.IsAdmin) &&
                (request.MemberType == null) || (request.MemberType == u.MemberType)
            ).Select(u =>
                new UserDto(
                    u.Id,
                    u.CID,
                    u.Email,
                    u.FullName,
                    u.IsAdmin,
                    u.MemberType
                )
            ).ToArrayAsync(cancellationToken);

        return CommandResult.WithResult(result);
    }
}