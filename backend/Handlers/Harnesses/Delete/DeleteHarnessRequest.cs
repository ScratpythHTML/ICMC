using Audacia.Commands;
using MediatR;

namespace Handlers.Harnesses.Delete;

/// <summary>
/// A request to delete a harness by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteHarnessRequest(int Id) : IRequest<CommandResult>;
