using Audacia.Commands;
using Domain.Entities;
using EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Users.Dtos;

namespace Services.Users.Search;

/// <summary>
/// Service to search users.
/// </summary>
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

        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(request.Search))
        {
            var searchTerm = request.Search.ToLower();
            query = query.Where(u =>
                (u.CID != null && u.CID.ToLower().Contains(searchTerm)) ||
                (u.Email != null && u.Email.ToLower().Contains(searchTerm)) ||
                (u.FullName != null && u.FullName.ToLower().Contains(searchTerm))
            );
        }

        var result = await query
            .Where(u =>
                (string.IsNullOrEmpty(request.CID) || (u.CID != null && u.CID.StartsWith(request.CID))) &&
                (string.IsNullOrEmpty(request.Email) || (u.Email != null && u.Email.StartsWith(request.Email))) &&
                (string.IsNullOrEmpty(request.FullName) || (u.FullName != null && u.FullName.ToLower().Contains(request.FullName.ToLower()))) &&
                (request.IsAdmin == null || request.IsAdmin == u.IsAdmin) &&
                (request.MemberType == null || request.MemberType == u.MemberType)
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