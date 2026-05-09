using Audacia.Commands;
using MediatR;

namespace Services.GearItems.Get;

/// <summary>
/// Interface for the service that gets belay devices.
/// </summary>
public interface IGetGearItemsService : IRequestHandler<GetGearItemsRequest, CommandResult<GearItemDto[]>>;