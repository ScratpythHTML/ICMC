using Audacia.Commands;
using MediatR;

namespace Services.Users.Update;

/// <summary>
/// The interface for the service that updates a user.
/// </summary>
public interface IUpdateUserService : IRequestHandler<UpdateUserRequest, CommandResult>
{
}
