using Audacia.Commands;
using MediatR;

namespace Services.BelayDevices.Delete;

/// <summary>
/// The interface for the service that deletes a belay device.
/// </summary>
public interface IDeleteBelayDeviceService : IRequestHandler<DeleteBelayDeviceRequest, CommandResult>
{
}