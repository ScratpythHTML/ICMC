using MediatR;
using Audacia.Commands;

namespace Handlers.Ropes.Get;

/// <summary>
/// The inferface for the handler that gets a rope.
/// </summary>
public interface IGetRopeHandler : IRequestHandler<GetRopeRequest, CommandResult<RopeDto>>
{
}
