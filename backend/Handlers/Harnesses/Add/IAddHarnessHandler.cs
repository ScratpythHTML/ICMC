using Audacia.Commands;
using MediatR;

namespace Handlers.Harnesses.Add;

/// <summary>
/// The interface for the handler that adds a harness.
/// </summary>
public interface IAddHarnessHandler : IRequestHandler<AddHarnessRequest, CommandResult>
{
}
