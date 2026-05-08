using Audacia.Commands;
using Domain.Entities;
using MediatR;

namespace Services.BelayDevices.Get;

/// <summary>
/// The empty request for getting all belay devices.
/// </summary>
public record GetBelayDevicesRequest(StorageLocation storageLocation) : IRequest<CommandResult<BelayDeviceDto[]>>;