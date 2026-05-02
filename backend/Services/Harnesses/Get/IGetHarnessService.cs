using Audacia.Commands;
using MediatR;

namespace Services.Harnesses.Get;

/// <summary>
/// The inferface for the service that gets a harness.
/// </summary>
public interface IGetHarnessService : IRequestHandler<GetHarnessRequest, CommandResult<HarnessDto>>
{
}
