using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.GearItems.Get;

/// <summary>
/// Request to get all gear items of a given category and storage location.
/// </summary>
/// <param name="GearCategory"></param>
/// <param name="StorageLocation"></param>
public record GetGearItemsRequest(GearCategory? GearCategory, StorageLocation? StorageLocation) : IRequest<CommandResult<GearItemDto[]>>;