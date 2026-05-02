using Audacia.Commands;
using MediatR;

namespace Services.Carabiners.Delete;

/// <summary>
/// The interface for the service that deletes a carabiner.
/// </summary>
public interface IDeleteCarabinerService : IRequestHandler<DeleteCarabinerRequest, CommandResult>
{
}
