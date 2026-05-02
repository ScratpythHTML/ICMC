using Audacia.Commands;
using MediatR;

namespace Services.Ropes.Delete;

/// <summary>
/// The interface for the service that deletes a rope.
/// </summary>
public interface IDeleteRopeService : IRequestHandler<DeleteRopeRequest, CommandResult>
{
}
