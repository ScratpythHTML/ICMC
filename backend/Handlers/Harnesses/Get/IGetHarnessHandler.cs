using MediatR;
using Audacia.Commands;

namespace Handlers.Harnesses.Get;

/// <summary>
/// The inferface for the handler that gets a harness.
/// </summary>
public interface IGetHarnessHandler : IRequestHandler<GetHarnessRequest, CommandResult<HarnessDto>>
{
}
