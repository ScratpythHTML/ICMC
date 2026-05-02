using Audacia.Commands;
using MediatR;

namespace Services.Users.Delete;

/// <summary>
/// The interface for the service that deletes a user.
/// </summary>
public interface IDeleteUserService : IRequestHandler<DeleteUserRequest, CommandResult>
{
}
