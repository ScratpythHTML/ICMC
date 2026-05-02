using Audacia.Commands;
using MediatR;

namespace Services.BelayDevices.Get;

/// <summary>
/// The inferface for the service that gets a belay device.
/// </summary>
public interface IGetBelayDeviceService : IRequestHandler<GetBelayDeviceRequest, CommandResult<BelayDeviceDto>>
{
}