using Audacia.Commands;
using MediatR;

namespace Services.Helmets.Delete;

/// <summary>
/// The interface for the service that deletes a helmet.
/// </summary>
public interface IDeleteHelmetService : IRequestHandler<DeleteHelmetRequest, CommandResult>
{
}
