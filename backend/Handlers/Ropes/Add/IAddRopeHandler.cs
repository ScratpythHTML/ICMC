using Audacia.Commands;
using MediatR;

namespace Handlers.Ropes.Add;

/// <summary>
/// The interface for the handler that adds a rope.
/// </summary>
public interface IAddRopeHandler : IRequestHandler<AddRopeRequest, CommandResult>
{
}
