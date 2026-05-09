using Audacia.Commands;
using MediatR;

namespace Services.GearItems.Delete;

/// <summary>
/// A request to delete a gear item by ID.
/// </summary>
/// <param name="Id"></param>
public record DeleteGearItemRequest(int Id) : IRequest<CommandResult>;