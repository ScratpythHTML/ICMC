using Audacia.Commands;
using MediatR;

namespace Services.GearItems.Get;

/// <summary>
/// A request to get a gear item by ID.
/// </summary>
/// <param name="Id"></param>
public record GetGearItemRequest(int Id) : IRequest<CommandResult<GearItemDto>>;