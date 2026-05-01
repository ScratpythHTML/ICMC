using Audacia.Commands;
using MediatR;

namespace Handlers.BelayDevices.Update;

/// <summary>
/// The interface for the handler that updates a belay device.
/// </summary>
public interface IUpdateBelayDeviceHandler : IRequestHandler<UpdateBelayDeviceRequest, CommandResult>
{
}