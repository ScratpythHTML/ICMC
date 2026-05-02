using Audacia.Commands;
using MediatR;

namespace Services.Harnesses.Add;

/// <summary>
/// The interface for the service that adds a harness.
/// </summary>
public interface IAddHarnessService : IRequestHandler<AddHarnessRequest, CommandResult>
{
}
