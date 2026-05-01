using Audacia.Commands;
using MediatR;

namespace Handlers.Ropes.Delete;

/// <summary>
/// The interface for the handler that deletes a rope.
/// </summary>
public interface IDeleteRopeHandler : IRequestHandler<DeleteRopeRequest, CommandResult>
{
}
