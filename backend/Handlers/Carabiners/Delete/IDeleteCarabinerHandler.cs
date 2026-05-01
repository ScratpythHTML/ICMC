using Audacia.Commands;
using MediatR;

namespace Handlers.Carabiners.Delete;

/// <summary>
/// The interface for the handler that deletes a carabiner.
/// </summary>
public interface IDeleteCarabinerHandler : IRequestHandler<DeleteCarabinerRequest, CommandResult>
{
}
