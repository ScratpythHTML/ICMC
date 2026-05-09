using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.GearItems.Get;

/// <summary>
/// A request to get a gear item by ID, gear category and storage location.
/// </summary>
/// <param name="Id"></param>
/// <param name="GearCategory"></param>
/// <param name="StorageLocation"></param>
public record GetGearItemRequest(int Id, GearCategory? GearCategory, StorageLocation? StorageLocation) : IRequest<CommandResult<GearItemDto>>;