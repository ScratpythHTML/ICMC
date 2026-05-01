using Audacia.Commands;
using MediatR;

namespace Handlers.Helmets.Delete;

/// <summary>
/// The interface for the handler that deletes a helmet.
/// </summary>
public interface IDeleteHelmetHandler : IRequestHandler<DeleteHelmetRequest, CommandResult>
{
}
