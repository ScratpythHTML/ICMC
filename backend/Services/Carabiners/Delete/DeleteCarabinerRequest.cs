using Audacia.Commands;
using MediatR;

namespace Services.Carabiners.Delete;

/// <summary>
/// A request to delete a carabiner by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteCarabinerRequest(int Id) : IRequest<CommandResult>;
