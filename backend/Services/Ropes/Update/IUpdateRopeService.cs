using Audacia.Commands;
using MediatR;

namespace Services.Ropes.Update;

/// <summary>
/// The interface for the service that updates a rope.
/// </summary>
public interface IUpdateRopeService : IRequestHandler<UpdateRopeRequest, CommandResult>
{
}
