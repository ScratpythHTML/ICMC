using Audacia.Commands;
using MediatR;
using Services.GearItems.Dtos;

namespace Services.GearItems.Get;

/// <summary>
/// The interface for the service that gets a gear item.
/// </summary>
public interface IGetGearItemService : IRequestHandler<GetGearItemRequest, CommandResult<GearItemDto>>
{
}