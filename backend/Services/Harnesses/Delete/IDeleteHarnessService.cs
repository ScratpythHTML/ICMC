using Audacia.Commands;
using MediatR;

namespace Services.Harnesses.Delete;

/// <summary>
/// The interface for the service that deletes a harness.
/// </summary>
public interface IDeleteHarnessService : IRequestHandler<DeleteHarnessRequest, CommandResult>
{
}
