using Audacia.Commands;
using MediatR;

namespace Handlers.Harnesses.Delete;

/// <summary>
/// The interface for the handler that deletes a harness.
/// </summary>
public interface IDeleteHarnessHandler : IRequestHandler<DeleteHarnessRequest, CommandResult>
{
}
