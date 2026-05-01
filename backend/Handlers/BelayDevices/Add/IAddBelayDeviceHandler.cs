using Audacia.Commands;
using MediatR;

namespace Handlers.BelayDevices.Add;

/// <summary>
/// The interface for the handler that adds a belay device.
/// </summary>
public interface IAddBelayDeviceHandler : IRequestHandler<AddBelayDeviceRequest, CommandResult>
{
}