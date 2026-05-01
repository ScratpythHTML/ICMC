using Audacia.Commands;
using MediatR;

namespace Handlers.Helmets.Add;

/// <summary>
/// The interface for the handler that adds a helmet.
/// </summary>
public interface IAddHelmetHandler : IRequestHandler<AddHelmetRequest, CommandResult>
{
}
