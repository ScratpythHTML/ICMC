using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.GearItems.Get;

/// <summary>
/// Request to get all gear items of a given category and storage location.
/// </summary>
/// <param name="gearCategory"></param>
/// <param name="storageLocation"></param>
public record GetGearItemsRequest(GearCategory gearCategory, StorageLocation storageLocation) : IRequest<CommandResult<GearItemDto[]>>;