using Audacia.Commands;
using MediatR;

namespace Handlers.Ropes.Delete;

/// <summary>
/// A request to delete a rope by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteRopeRequest(int Id) : IRequest<CommandResult>;
