using Audacia.Commands;
using MediatR;

namespace Handlers.Ropes.Update;

/// <summary>
/// The interface for the handler that updates a rope.
/// </summary>
public interface IUpdateRopeHandler : IRequestHandler<UpdateRopeRequest, CommandResult>
{
}
