using Audacia.Commands;
using MediatR;

namespace Services.BelayDevices.Add;

/// <summary>
/// The interface for the service that adds a belay device.
/// </summary>
public interface IAddBelayDeviceService : IRequestHandler<AddBelayDeviceRequest, CommandResult>
{
}