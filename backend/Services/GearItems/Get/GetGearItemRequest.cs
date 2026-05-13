using Audacia.Commands;
using MediatR;
using Services.GearItems.Dtos;

namespace Services.GearItems.Get;

/// <summary>
/// A request to get a gear item by ID, gear category and storage location.
/// </summary>
/// <param name="Id"></param>
public record GetGearItemRequest(int Id) : IRequest<CommandResult<GearItemDto>>;