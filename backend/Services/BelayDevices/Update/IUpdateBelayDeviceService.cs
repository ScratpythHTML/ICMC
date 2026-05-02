using Audacia.Commands;
using MediatR;

namespace Services.BelayDevices.Update;

/// <summary>
/// The interface for the service that updates a belay device.
/// </summary>
public interface IUpdateBelayDeviceService : IRequestHandler<UpdateBelayDeviceRequest, CommandResult>
{
}