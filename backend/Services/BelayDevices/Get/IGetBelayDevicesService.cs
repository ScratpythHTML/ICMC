using Audacia.Commands;
using MediatR;

namespace Services.BelayDevices.Get;

/// <summary>
/// Interface for the service that gets belay devices.
/// </summary>
public interface IGetBelayDevicesService : IRequestHandler<GetBelayDevicesRequest, CommandResult<BelayDeviceDto[]>>;