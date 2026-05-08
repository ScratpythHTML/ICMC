using Audacia.Commands;
using MediatR;

namespace Services.Harnesses.Get;

/// <summary>
/// Interface for the service that gets harnesses.
/// </summary>
public interface IGetHarnessesService : IRequestHandler<GetHarnessesRequest, CommandResult<HarnessDto[]>>;