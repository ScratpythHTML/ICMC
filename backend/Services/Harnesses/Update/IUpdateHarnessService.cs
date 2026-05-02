using Audacia.Commands;
using MediatR;

namespace Services.Harnesses.Update;

/// <summary>
/// The interface for the service that updates a harness.
/// </summary>
public interface IUpdateHarnessService : IRequestHandler<UpdateHarnessRequest, CommandResult>
{
}
