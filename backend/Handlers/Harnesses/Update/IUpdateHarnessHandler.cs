using Audacia.Commands;
using MediatR;

namespace Handlers.Harnesses.Update;

/// <summary>
/// The interface for the handler that updates a harness.
/// </summary>
public interface IUpdateHarnessHandler : IRequestHandler<UpdateHarnessRequest, CommandResult>
{
}
