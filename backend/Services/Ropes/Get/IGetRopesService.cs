using Audacia.Commands;
using MediatR;

namespace Services.Ropes.Get;

/// <summary>
/// Interface for the service that gets ropes.
/// </summary>
public interface IGetRopesService : IRequestHandler<GetRopesRequest, CommandResult<RopeDto[]>>;