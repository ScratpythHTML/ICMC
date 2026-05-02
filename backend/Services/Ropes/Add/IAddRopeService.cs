using Audacia.Commands;
using MediatR;

namespace Services.Ropes.Add;

/// <summary>
/// The interface for the service that adds a rope.
/// </summary>
public interface IAddRopeService : IRequestHandler<AddRopeRequest, CommandResult>
{
}
