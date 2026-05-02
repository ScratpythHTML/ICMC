using Audacia.Commands;
using MediatR;

namespace Services.Helmets.Delete;

/// <summary>
/// A request to delete a helmet by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteHelmetRequest(int Id) : IRequest<CommandResult>;
