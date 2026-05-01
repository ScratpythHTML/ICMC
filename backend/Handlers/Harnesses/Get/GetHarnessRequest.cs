using MediatR;
using Audacia.Commands;

namespace Handlers.Harnesses.Get;

/// <summary>
/// A request to get a harness by ID.
/// </summary>
/// <param name="Id"></param>
public record GetHarnessRequest(int Id) : IRequest<CommandResult<HarnessDto>>;
