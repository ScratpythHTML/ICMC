using Audacia.Commands;
using MediatR;

namespace Handlers.BelayDevices.Get;

/// <summary>
/// The inferface for the handler that gets a belay device.
/// </summary>
public interface IGetBelayDeviceHandler : IRequestHandler<GetBelayDeviceRequest, CommandResult<BelayDeviceDto>>
{
}