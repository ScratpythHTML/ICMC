using Audacia.Commands;
using MediatR;

namespace Services.Helmets.Get;

/// <summary>
/// Interface for the service that gets helmets.
/// </summary>
public interface IGetHelmetsService : IRequestHandler<GetHelmetsRequest, CommandResult<HelmetDto[]>>;