using Audacia.Commands;
using MediatR;

namespace Services.Ropes.Get;

/// <summary>
/// The inferface for the service that gets a rope.
/// </summary>
public interface IGetRopeService : IRequestHandler<GetRopeRequest, CommandResult<RopeDto>>
{
}
