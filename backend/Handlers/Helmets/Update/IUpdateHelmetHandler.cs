using Audacia.Commands;
using MediatR;

namespace Handlers.Helmets.Update;

/// <summary>
/// The interface for the handler that updates a helmet.
/// </summary>
public interface IUpdateHelmetHandler : IRequestHandler<UpdateHelmetRequest, CommandResult>
{
}
